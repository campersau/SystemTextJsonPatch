﻿using System;
using System.Text.Json;
using SystemTextJsonPatch.Internal;
using SystemTextJsonPatch.Operations;

namespace SystemTextJsonPatch.Adapters;

/// <inheritdoc />
public class ObjectAdapter : IObjectAdapterWithTest
{
    /// <summary>
    /// Initializes a new instance of <see cref="ObjectAdapter"/>.
    /// </summary>
    /// <param name="contractResolver">The <see cref="IContractResolver"/>.</param>
    /// <param name="logErrorAction">The <see cref="Action"/> for logging <see cref="JsonPatchError"/>.</param>
    public ObjectAdapter(
        JsonSerializerOptions options,
        Action<JsonPatchError> logErrorAction) :
        this(options, logErrorAction, Adapters.AdapterFactory.Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ObjectAdapter"/>.
    /// </summary>
    /// <param name="contractResolver">The <see cref="IContractResolver"/>.</param>
    /// <param name="logErrorAction">The <see cref="Action"/> for logging <see cref="JsonPatchError"/>.</param>
    /// <param name="adapterFactory">The <see cref="IAdapterFactory"/> to use when creating adaptors.</param>
    public ObjectAdapter(
       JsonSerializerOptions options,
       Action<JsonPatchError> logErrorAction,
       IAdapterFactory adapterFactory)
    {
        Options = options ?? throw new ArgumentNullException(nameof(options));
        LogErrorAction = logErrorAction;
        AdapterFactory = adapterFactory ?? throw new ArgumentNullException(nameof(adapterFactory));
    }

    /// <summary>
    /// Gets or sets the <see cref="IContractResolver"/>.
    /// </summary>
    public JsonSerializerOptions Options { get; }

    /// <summary>
    /// Gets or sets the <see cref="IAdapterFactory"/>
    /// </summary>
    public IAdapterFactory AdapterFactory { get; }

    /// <summary>
    /// Action for logging <see cref="JsonPatchError"/>.
    /// </summary>
    public Action<JsonPatchError> LogErrorAction { get; }

    public void Add(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        Add(operation.path, operation.value, objectToApplyTo, operation);
    }

    /// <summary>
    /// Add is used by various operations (eg: add, copy, ...), yet through different operations;
    /// This method allows code reuse yet reporting the correct operation on error
    /// </summary>
    private void Add(
        string path,
        object value,
        object objectToApplyTo,
        Operation operation
    )
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        var parsedPath = new ParsedPath(path);
        var visitor = new ObjectVisitor(parsedPath, Options, AdapterFactory);

        var target = objectToApplyTo;
        if (!visitor.TryVisit(ref target, out var adapter, out var errorMessage))
        {
            var error = CreatePathNotFoundError(objectToApplyTo, path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }

        if (!adapter.TryAdd(target, parsedPath.LastSegment, Options, value, out errorMessage))
        {
            var error = CreateOperationFailedError(objectToApplyTo, path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }
    }

    public void Move(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        // Get value at 'from' location and add that value to the 'path' location
        if (TryGetValue(operation.from, objectToApplyTo, operation, out var propertyValue))
        {
            // remove that value
            Remove(operation.from, objectToApplyTo, operation);

            // add that value to the path location
            Add(operation.path,
                propertyValue,
                objectToApplyTo,
                operation);
        }
    }

    public void Remove(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        Remove(operation.path, objectToApplyTo, operation);
    }

    /// <summary>
    /// Remove is used by various operations (eg: remove, move, ...), yet through different operations;
    /// This method allows code reuse yet reporting the correct operation on error.  The return value
    /// contains the type of the item that has been removed (and a bool possibly signifying an error)
    /// This can be used by other methods, like replace, to ensure that we can pass in the correctly
    /// typed value to whatever method follows.
    /// </summary>
    private void Remove(string path, object objectToApplyTo, Operation operationToReport)
    {
        var parsedPath = new ParsedPath(path);
        var visitor = new ObjectVisitor(parsedPath, Options, AdapterFactory);

        var target = objectToApplyTo;
        if (!visitor.TryVisit(ref target, out var adapter, out var errorMessage))
        {
            var error = CreatePathNotFoundError(objectToApplyTo, path, operationToReport, errorMessage);
            ErrorReporter(error);
            return;
        }

        if (!adapter.TryRemove(target, parsedPath.LastSegment, Options, out errorMessage))
        {
            var error = CreateOperationFailedError(objectToApplyTo, path, operationToReport, errorMessage);
            ErrorReporter(error);
            return;
        }
    }

    public void Replace(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        var parsedPath = new ParsedPath(operation.path);
        var visitor = new ObjectVisitor(parsedPath, Options, AdapterFactory);

        var target = objectToApplyTo;
        if (!visitor.TryVisit(ref target, out var adapter, out var errorMessage))
        {
            var error = CreatePathNotFoundError(objectToApplyTo, operation.path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }

        if (!adapter.TryReplace(target, parsedPath.LastSegment, Options, operation.value, out errorMessage))
        {
            var error = CreateOperationFailedError(objectToApplyTo, operation.path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }
    }

    public void Copy(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        // Get value at 'from' location and add that value to the 'path' location
        if (TryGetValue(operation.from, objectToApplyTo, operation, out var propertyValue))
        {
            // Create deep copy
            if (ConversionResultProvider.TryCopyTo(propertyValue, propertyValue?.GetType(), out object convertedValue))
            {
                Add(operation.path,
                    convertedValue,
                    objectToApplyTo,
                    operation);
            }
            else
            {
                var error = CreateOperationFailedError(objectToApplyTo, operation.path, operation, Resources.FormatCannotCopyProperty(operation.from));
                ErrorReporter(error);
                return;
            }
        }
    }

    public void Test(Operation operation, object objectToApplyTo)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        if (objectToApplyTo == null)
        {
            throw new ArgumentNullException(nameof(objectToApplyTo));
        }

        var parsedPath = new ParsedPath(operation.path);
        var visitor = new ObjectVisitor(parsedPath, Options, AdapterFactory);

        var target = objectToApplyTo;
        if (!visitor.TryVisit(ref target, out var adapter, out var errorMessage))
        {
            var error = CreatePathNotFoundError(objectToApplyTo, operation.path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }

        if (!adapter.TryTest(target, parsedPath.LastSegment, Options, operation.value, out errorMessage))
        {
            var error = CreateOperationFailedError(objectToApplyTo, operation.path, operation, errorMessage);
            ErrorReporter(error);
            return;
        }
    }

    private bool TryGetValue(
        string fromLocation,
        object objectToGetValueFrom,
        Operation operation,
        out object propertyValue)
    {
        if (fromLocation == null)
        {
            throw new ArgumentNullException(nameof(fromLocation));
        }

        if (objectToGetValueFrom == null)
        {
            throw new ArgumentNullException(nameof(objectToGetValueFrom));
        }

        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        propertyValue = null;

        var parsedPath = new ParsedPath(fromLocation);
        var visitor = new ObjectVisitor(parsedPath, Options, AdapterFactory);

        var target = objectToGetValueFrom;
        if (!visitor.TryVisit(ref target, out var adapter, out var errorMessage))
        {
            var error = CreatePathNotFoundError(objectToGetValueFrom, fromLocation, operation, errorMessage);
            ErrorReporter(error);
            return false;
        }

        if (!adapter.TryGet(target, parsedPath.LastSegment, Options, out propertyValue, out errorMessage))
        {
            var error = CreateOperationFailedError(objectToGetValueFrom, fromLocation, operation, errorMessage);
            ErrorReporter(error);
            return false;
        }

        return true;
    }

    private Action<JsonPatchError> ErrorReporter
    {
        get
        {
            return LogErrorAction ?? Internal.ErrorReporter.Default;
        }
    }

    private static JsonPatchError CreateOperationFailedError(object target, string path, Operation operation, string errorMessage)
    {
        return new JsonPatchError(
            target,
            operation,
            errorMessage ?? Resources.FormatCannotPerformOperation(operation.op, path));
    }

    private static JsonPatchError CreatePathNotFoundError(object target, string path, Operation operation, string errorMessage)
    {
        return new JsonPatchError(
            target,
            operation,
            errorMessage ?? Resources.FormatTargetLocationNotFound(operation.op, path));
    }
}

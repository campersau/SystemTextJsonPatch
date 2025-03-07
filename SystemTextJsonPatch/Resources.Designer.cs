﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemTextJsonPatch {
    using System;
    using System.Globalization;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SystemTextJsonPatch.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property at &apos;{0}&apos; could not be copied..
        /// </summary>
        public static string CannotCopyProperty {
            get {
                return ResourceManager.GetString("CannotCopyProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of the property at path &apos;{0}&apos; could not be determined..
        /// </summary>
        public static string CannotDeterminePropertyType {
            get {
                return ResourceManager.GetString("CannotDeterminePropertyType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; operation at path &apos;{1}&apos; could not be performed..
        /// </summary>
        public static string CannotPerformOperation {
            get {
                return ResourceManager.GetString("CannotPerformOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property at &apos;{0}&apos; could not be read..
        /// </summary>
        public static string CannotReadProperty {
            get {
                return ResourceManager.GetString("CannotReadProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property at path &apos;{0}&apos; could not be updated..
        /// </summary>
        public static string CannotUpdateProperty {
            get {
                return ResourceManager.GetString("CannotUpdateProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The expression &apos;{0}&apos; is not supported. Supported expressions include member access and indexer expressions..
        /// </summary>
        public static string ExpressionTypeNotSupported {
            get {
                return ResourceManager.GetString("ExpressionTypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The index value provided by path segment &apos;{0}&apos; is out of bounds of the array size..
        /// </summary>
        public static string IndexOutOfBounds {
            get {
                return ResourceManager.GetString("IndexOutOfBounds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path segment &apos;{0}&apos; is invalid for an array index..
        /// </summary>
        public static string InvalidIndexValue {
            get {
                return ResourceManager.GetString("InvalidIndexValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The JSON patch document was malformed and could not be parsed..
        /// </summary>
        public static string InvalidJsonPatchDocument {
            get {
                return ResourceManager.GetString("InvalidJsonPatchDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid JsonPatch operation &apos;{0}&apos;..
        /// </summary>
        public static string InvalidJsonPatchOperation {
            get {
                return ResourceManager.GetString("InvalidJsonPatchOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided path segment &apos;{0}&apos; cannot be converted to the target type..
        /// </summary>
        public static string InvalidPathSegment {
            get {
                return ResourceManager.GetString("InvalidPathSegment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided string &apos;{0}&apos; is an invalid path..
        /// </summary>
        public static string InvalidValueForPath {
            get {
                return ResourceManager.GetString("InvalidValueForPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &apos;{0}&apos; is invalid for target location..
        /// </summary>
        public static string InvalidValueForProperty {
            get {
                return ResourceManager.GetString("InvalidValueForProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; must be of type &apos;{1}&apos;..
        /// </summary>
        public static string ParameterMustMatchType {
            get {
                return ResourceManager.GetString("ParameterMustMatchType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; which is an array is not supported for json patch operations as it has a fixed size..
        /// </summary>
        public static string PatchNotSupportedForArrays {
            get {
                return ResourceManager.GetString("PatchNotSupportedForArrays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; which is a non generic list is not supported for json patch operations. Only generic list types are supported..
        /// </summary>
        public static string PatchNotSupportedForNonGenericLists {
            get {
                return ResourceManager.GetString("PatchNotSupportedForNonGenericLists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The target location specified by path segment &apos;{0}&apos; was not found..
        /// </summary>
        public static string TargetLocationAtPathSegmentNotFound {
            get {
                return ResourceManager.GetString("TargetLocationAtPathSegmentNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For operation &apos;{0}&apos;, the target location specified by path &apos;{1}&apos; was not found..
        /// </summary>
        public static string TargetLocationNotFound {
            get {
                return ResourceManager.GetString("TargetLocationNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The test operation is not supported..
        /// </summary>
        public static string TestOperationNotSupported {
            get {
                return ResourceManager.GetString("TestOperationNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current value &apos;{0}&apos; at position &apos;{2}&apos; is not equal to the test value &apos;{1}&apos;..
        /// </summary>
        public static string ValueAtListPositionNotEqualToTestValue {
            get {
                return ResourceManager.GetString("ValueAtListPositionNotEqualToTestValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value at &apos;{0}&apos; cannot be null or empty to perform the test operation..
        /// </summary>
        public static string ValueForTargetSegmentCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ValueForTargetSegmentCannotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current value &apos;{0}&apos; at path &apos;{2}&apos; is not equal to the test value &apos;{1}&apos;..
        /// </summary>
        public static string ValueNotEqualToTestValue {
            get {
                return ResourceManager.GetString("ValueNotEqualToTestValue", resourceCulture);
            }
        }

        /// <summary>
        /// The property at '{0}' could not be copied.
        /// </summary>
        internal static string FormatCannotCopyProperty(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("CannotCopyProperty"), p0);

        /// <summary>
        /// The type of the property at path '{0}' could not be determined.
        /// </summary>
        internal static string FormatCannotDeterminePropertyType(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("CannotDeterminePropertyType"), p0);

        /// <summary>
        /// The '{0}' operation at path '{1}' could not be performed.
        /// </summary>
        internal static string FormatCannotPerformOperation(object p0, object p1)
            => string.Format(CultureInfo.CurrentCulture, GetString("CannotPerformOperation"), p0, p1);

        /// <summary>
        /// The property at '{0}' could not be read.
        /// </summary>
        internal static string FormatCannotReadProperty(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("CannotReadProperty"), p0);

        /// <summary>
        /// The property at path '{0}' could not be updated.
        /// </summary>
        internal static string FormatCannotUpdateProperty(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("CannotUpdateProperty"), p0);

        /// <summary>
        /// The expression '{0}' is not supported.
        /// </summary>
        internal static string FormatExpressionTypeNotSupported(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("ExpressionTypeNotSupported"), p0);

        /// <summary>
        /// The index value provided by path segment '{0}' is out of bounds of the array size.
        /// </summary>
        internal static string FormatIndexOutOfBounds(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("IndexOutOfBounds"), p0);

        /// <summary>
        /// The path segment '{0}' is invalid for an array index.
        /// </summary>
        internal static string FormatInvalidIndexValue(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidIndexValue"), p0);

        /// <summary>
        /// The type '{0}' was malformed and could not be parsed.
        /// </summary>
        internal static string FormatInvalidJsonPatchDocument(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidJsonPatchDocument"), p0);

        /// <summary>
        /// Invalid JsonPatch operation '{0}'.
        /// </summary>
        internal static string FormatInvalidJsonPatchOperation(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidJsonPatchOperation"), p0);

        /// <summary>
        /// The provided path segment '{0}' cannot be converted to the target type.
        /// </summary>
        internal static string FormatInvalidPathSegment(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidPathSegment"), p0);

        /// <summary>
        /// The provided string '{0}' is an invalid path.
        /// </summary>
        internal static string FormatInvalidValueForPath(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidValueForPath"), p0);

        /// <summary>
        /// The value '{0}' is invalid for target location.
        /// </summary>
        internal static string FormatInvalidValueForProperty(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("InvalidValueForProperty"), p0);

        /// <summary>
        /// '{0}' must be of type '{1}'.
        /// </summary>
        internal static string FormatParameterMustMatchType(object p0, object p1)
            => string.Format(CultureInfo.CurrentCulture, GetString("ParameterMustMatchType"), p0, p1);

        /// <summary>
        /// The type '{0}' which is an array is not supported for json patch operations as it has a fixed size.
        /// </summary>
        internal static string FormatPatchNotSupportedForArrays(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("PatchNotSupportedForArrays"), p0);

        /// <summary>
        /// The type '{0}' which is a non generic list is not supported for json patch operations. Only generic list types are supported.
        /// </summary>
        internal static string FormatPatchNotSupportedForNonGenericLists(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("PatchNotSupportedForNonGenericLists"), p0);

        /// <summary>
        /// The target location specified by path segment '{0}' was not found.
        /// </summary>
        internal static string FormatTargetLocationAtPathSegmentNotFound(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("TargetLocationAtPathSegmentNotFound"), p0);

        /// <summary>
        /// For operation '{0}', the target location specified by path '{1}' was not found.
        /// </summary>
        internal static string FormatTargetLocationNotFound(object p0, object p1)
            => string.Format(CultureInfo.CurrentCulture, GetString("TargetLocationNotFound"), p0, p1);

        /// <summary>
        /// The test operation is not supported.
        /// </summary>
        internal static string FormatTestOperationNotSupported()
            => GetString("TestOperationNotSupported");

        /// <summary>
        /// The current value '{0}' at position '{2}' is not equal to the test value '{1}'.
        /// </summary>
        internal static string FormatValueAtListPositionNotEqualToTestValue(object p0, object p1, object p2)
            => string.Format(CultureInfo.CurrentCulture, GetString("ValueAtListPositionNotEqualToTestValue"), p0, p1, p2);

        /// <summary>
        /// The value at '{0}' cannot be null or empty to perform the test operation.
        /// </summary>
        internal static string FormatValueForTargetSegmentCannotBeNullOrEmpty(object p0)
            => string.Format(CultureInfo.CurrentCulture, GetString("ValueForTargetSegmentCannotBeNullOrEmpty"), p0);


        /// <summary>
        /// The current value '{0}' at path '{2}' is not equal to the test value '{1}'.
        /// </summary>
        internal static string FormatValueNotEqualToTestValue(object p0, object p1, object p2)
            => string.Format(CultureInfo.CurrentCulture, GetString("ValueNotEqualToTestValue"), p0, p1, p2);


        private static string GetString(string name, params string[] formatterNames)
        {
            var value = ResourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }

    }
}

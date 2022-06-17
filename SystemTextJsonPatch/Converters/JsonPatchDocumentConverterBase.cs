using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SystemTextJsonPatch.Exceptions;
using SystemTextJsonPatch.Operations;

namespace SystemTextJsonPatch.Converters
{
    public abstract class JsonPatchDocumentConverterBase<TType, TOperation> : JsonConverter<TType>
        where TType : class, IJsonPatchDocument, new()
        where TOperation : Operation, new()


    {

        private static readonly JsonEncodedText OpText = JsonEncodedText.Encode("op");
        private static readonly JsonEncodedText PathText = JsonEncodedText.Encode("path");
        private static readonly JsonEncodedText FromText = JsonEncodedText.Encode("from");
        private static readonly JsonEncodedText ValueText = JsonEncodedText.Encode("value");

        protected List<TOperation> ParseOperations(ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var operations = new List<TOperation>();

                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonPatchException(Resources.InvalidJsonPatchDocument, null);
                    }

                    string op = null;
                    string path = null;
                    string from = null;
                    object val = null;

                    while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                    {
                        if (reader.TokenType != JsonTokenType.PropertyName)
                        {
                            throw new JsonPatchException(Resources.InvalidJsonPatchDocument, null);
                        }

                        if (reader.ValueTextEquals(OpText.EncodedUtf8Bytes))
                        {
                            CheckedRead(ref reader);
                            op = reader.GetString();
                        }
                        else if (reader.ValueTextEquals(PathText.EncodedUtf8Bytes))
                        {
                            CheckedRead(ref reader);
                            path = reader.GetString();
                        }
                        else if (reader.ValueTextEquals(FromText.EncodedUtf8Bytes))
                        {
                            CheckedRead(ref reader);
                            from = reader.GetString();
                        }
                        else if (reader.ValueTextEquals(ValueText.EncodedUtf8Bytes))
                        {
                            CheckedRead(ref reader);
                            switch (reader.TokenType)
                            {
                                case JsonTokenType.String:
                                    val = reader.GetString();
                                    break;
                                case JsonTokenType.Number:
                                    val = reader.GetDecimal();
                                    break;
                                case JsonTokenType.True:
                                    val = true;
                                    break;
                                case JsonTokenType.False:
                                    val = false;
                                    break;
                                case JsonTokenType.Null:
                                    val = null;
                                    break;
                                default:
                                    val = JsonElement.ParseValue(ref reader);
                                    break;
                            }
                        }
                        else
                        {
                            throw new JsonPatchException(Resources.InvalidJsonPatchDocument, null);
                        }
                    }

                    var operation = new TOperation
                    {
                        op = op,
                        path = path,
                        from = from,
                        value = val
                    };

                    operations.Add(operation);
                }

                return operations;
            }

            return null;
        }

        private static void CheckedRead(ref Utf8JsonReader reader)
        {
            if (!reader.Read())
            {
                throw new JsonPatchException(Resources.InvalidJsonPatchDocument, null);
            }
        }

        public override void Write(Utf8JsonWriter writer, TType value, JsonSerializerOptions options)
        {
            if (value is IJsonPatchDocument jsonPatchDoc)
            {
                var operations = jsonPatchDoc.GetOperations();

                writer.WriteStartArray();

                foreach (var operation in operations)
                {
                    writer.WriteStartObject();
                    writer.WriteString(OpText, operation.op);
                    writer.WriteString(PathText, operation.path);

                    if (!string.IsNullOrEmpty(operation.from))
                    {
                        writer.WriteString(FromText, operation.from);
                    }

                    writer.WritePropertyName(ValueText);
                    JsonSerializer.Serialize(writer, operation.value, options);
                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }
            else
            {
                throw new JsonPatchException(Resources.InvalidJsonPatchDocument, null);
            }
        }
    }
}

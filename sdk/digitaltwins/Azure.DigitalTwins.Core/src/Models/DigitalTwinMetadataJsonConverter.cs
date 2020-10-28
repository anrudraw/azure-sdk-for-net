// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
#pragma warning disable AZC0014 // Avoid using banned types in public API

    /// <summary>
    /// JSON converter to make it easier to deserialize a <see cref="BasicDigitalTwin"/>.
    /// </summary>
    public class DigitalTwinMetadataJsonConverter : JsonConverter<DigitalTwinMetadata>
    {
        /// <inheritdoc/>
        public override DigitalTwinMetadata Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var metadata = new DigitalTwinMetadata();
                reader.Read(); // Advance into our object.

                while (reader.TokenType != JsonTokenType.EndObject) // Until we reach the end of the object we began reading
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        if (reader.GetString() == DigitalTwinsJsonPropertyNames.MetadataModel)
                        {
                            reader.Read(); // advance to the string
                            metadata.ModelId = JsonSerializer.Deserialize<string>(ref reader, options);
                            reader.Read(); // Consume the string we deserialized
                        }
                        else
                        {
                            var propertyName = reader.GetString();
                            reader.Read(); // Should place us on StartObject
                            if (reader.TokenType == JsonTokenType.StartObject)
                            {
                                metadata.PropertyMetadata[propertyName] = JsonSerializer.Deserialize<DigitalTwinPropertyMetadata>(ref reader, options);
                                reader.Read(); // Consume EndObject
                            }
                        }
                    }
                }

                return metadata;
            }

            throw new Exception($"Unknown token type {reader.TokenType} at index {reader.TokenStartIndex}.");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, DigitalTwinMetadata value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(DigitalTwinsJsonPropertyNames.MetadataModel, value.ModelId);
            foreach (KeyValuePair<string, DigitalTwinPropertyMetadata> p in value.PropertyMetadata)
            {
                writer.WritePropertyName(p.Key);
                JsonSerializer.Serialize<DigitalTwinPropertyMetadata>(writer, p.Value, options);
            }
            writer.WriteEndObject();
        }
    }

#pragma warning restore AZC0014 // Avoid using banned types in public API
}

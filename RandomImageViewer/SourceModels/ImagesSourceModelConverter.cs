using RandomImageViewer.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomImageViewer.SourceModels
{
    public class ImagesSourceModelConverter : JsonConverter<BaseModel>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BaseModel).IsAssignableFrom(typeToConvert);
        }

        public override BaseModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string propertyName = reader.GetString();
            if (propertyName != "SourceType")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            SourceType sourceType = (SourceType)reader.GetInt32();
            BaseModel model;

            if (!reader.Read() || reader.GetString() != "Data")
            {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            switch (sourceType)
            {
                case SourceType.LocalImage:
                    model = (LocalImagesModel)JsonSerializer.Deserialize(ref reader, typeof(LocalImagesModel));
                    break;
                default:
                    throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return model;
        }

        public override void Write(Utf8JsonWriter writer, BaseModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

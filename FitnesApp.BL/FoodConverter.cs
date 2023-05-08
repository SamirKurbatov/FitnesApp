using FitnesApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnesApp.BL
{
    public class FoodDictionaryConverter : JsonConverter<Dictionary<Food, double>>
    {
        public override Dictionary<Food, double> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Не реализовано, поскольку десериализация не нужна в данном случае
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<Food, double> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var pair in value)
            {
                writer.WritePropertyName(pair.Key.Title);

                writer.WriteStartObject();
                writer.WritePropertyName("Weight");
                writer.WriteNumberValue(pair.Value);
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }
    }
}

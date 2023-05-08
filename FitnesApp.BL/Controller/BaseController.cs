using FitnesApp.BL.Models;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FitnesApp.BL.Controller
{
    public abstract class BaseController
    {
        protected void Save<T>(string fileName, T item)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new FoodDictionaryConverter() }
            };


            string jsonString = JsonSerializer.Serialize(item, options);
            File.WriteAllText(fileName, jsonString);
        }

        protected T? Load<T>(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (var fs = new FileStream(fileName, FileMode.Open))
                    {
                        if (fs.Length > 0 && JsonSerializer.Deserialize<T>(fs) is T items)
                        {
                            return items;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
                else
                {
                    return default(T);
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing file {fileName}: {ex.Message}");
                return default(T);
            }
        }
    }


}

using System.Text.Json;

namespace FitnesApp.BL.Controller
{
    internal class SerializeDataManager : IDataManager
    {
        public List<T>? Load<T>() where T : class
        {
            var fileName = typeof(T).Name + ".json";
            try
            {
                if (File.Exists(fileName))
                {
                    using (var fs = new FileStream(fileName, FileMode.Open))
                    {
                        if (fs.Length > 0 && JsonSerializer.Deserialize<List<T>>(fs) is List<T> items)
                        {
                            return items;
                        }
                        else
                        {
                            return new List<T>();
                        }
                    }
                }
                else
                {
                    return new List<T>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing file {fileName}: {ex.Message}");
                return new List<T>();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var fileName = typeof(T).Name + ".json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new FoodDictionaryConverter() }
            };


            string jsonString = JsonSerializer.Serialize(item, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}

using static BlazorAppDemo.Database.SQLiteContext;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace BlazorAppDemo.Database
{
    public class GetDataFromJson
    {
        public async  Task<IEnumerable<CarsModels>> ReadFromJsonFile()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),@"Database\carsData.json");
            string jsonString = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<IEnumerable<CarsModels>>(jsonString);
        }
    }
}

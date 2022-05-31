using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Database
{
    public class SQLiteContext : DbContext
    {
        public string DbPath { get; set; }
        public SQLiteContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "carsmodels.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
                                        builder.UseSqlite($"Data Source={DbPath}");

        public class CarsModels
        { 
            public int Id { get; set; }
            public string make { get; set; }
            public string model { get; set; }
            public int year { get; set; }
        }
        
    }
}

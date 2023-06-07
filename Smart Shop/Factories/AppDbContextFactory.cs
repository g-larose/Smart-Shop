using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Smart_Shop.Data;
using Smart_Shop.Models;
using System;
using System.IO;
using System.Text.Json;

namespace Smart_Shop.Factories
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[]? args = null)
        {
            var jsonFile = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data",
                "appsettings.json"));
            var json = JsonSerializer.Deserialize<ConfigJson>(jsonFile!);
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseNpgsql(json!.ConnectionString!);
            return new AppDbContext(options.Options);
        }
    }
}

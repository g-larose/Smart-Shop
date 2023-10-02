using Microsoft.EntityFrameworkCore;
using Smart_Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smart_Shop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "appsettings.json"));
            var conStr = JsonSerializer.Deserialize<JsonConfig>(json);
            optionsBuilder.UseNpgsql(conStr.ConnectionString);
        }
    }
}

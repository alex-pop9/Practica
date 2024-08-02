using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPractica.DbModel;

namespace ProiectPractica.Persistance
{
    public class ConfigurationContext : DbContext
    {
        public string DbPath { get; }
        public ConfigurationContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "configDB.db");
        }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<FileSettings> Paths { get; set; }
        public DbSet<ConfigurationLog> ConfigurationLog { get; set; }
        public DbSet<PathConfigurationLog> PathConfigurationLog { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}

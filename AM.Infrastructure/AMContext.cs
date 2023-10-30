using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Festival> Festivals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SaifZribi;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurer la clé primaire de la porteuse de données 
            modelBuilder.Entity<Concert>().HasKey(t => new { t.ArtisteFk, t.FestivalFk, t.DateConcert });

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar(50)");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}

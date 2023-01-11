using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MT4Hofer.models
{
    public class MeinContext : DbContext
    {
        public DbSet<Schulklasse> Schulklassen { get; set; }
        public DbSet<Schueler> Schueler { get; set; }
        public DbSet<Klassenbucheintrag> Klassenbucheintraege { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Klassenbuch;User Id=sa;Password=Admin2019$;");
        }
    }
}
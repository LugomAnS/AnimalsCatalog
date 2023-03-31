using DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace SQLDataProvider
{
    public class SqlLiteDataContext : DbContext
    {
        public DbSet<Amphibian> Amphibians { get; set; } = null!;
        public DbSet<Bird> Birds { get; set; } = null!;
        public DbSet<Mammal> Mammals { get; set; } = null!;

        public SqlLiteDataContext()
        {
            Database.EnsureCreated();
        }

        #region Overrides of DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Animal.db");
        }

        #endregion
    }
}

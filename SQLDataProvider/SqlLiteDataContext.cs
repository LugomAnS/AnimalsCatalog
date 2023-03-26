using DataModels;
using Microsoft.EntityFrameworkCore;

namespace SQLDataProvider
{
    public class SqlLiteDataContext : DbContext
    {
        public DbSet<IAnimal> Animals { get; set; } = null!;

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

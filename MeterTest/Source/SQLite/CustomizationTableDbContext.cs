using MeterTest.Source.Dlt645;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.source.SQLite
{
    public class CustomizationTableDbContext : DbContext
    {
        public DbSet<CustomizationTable> CustomizationTables { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CustomizationTables.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomizationTable>()
                .HasKey(b => b.Name)
                .HasName("PrimaryKey_Name");
        }
    }
}
using MeterTest.Source.Dlt645;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.SQLite.ParaConfig
{
    public class ParaConfigTableDbContext : DbContext
    {
        static private ParaConfigTableDbContext paraConfigTableDbContext = new ParaConfigTableDbContext();
        public DbSet<ParaConfigTable> ParaConfigTables { get; set; }
        public DbSet<ParaConfigDataId> DataIds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=ParaConfigTables.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ParaConfigTable>()
            //     .HasKey(b => b.Id)
            //     .HasName("PrimaryKey_Name");
            // modelBuilder.Entity<DataId>()
            // .HasOne(p => p.ParaConfigTable)
            // .WithMany(b => b.Posts)
            // .HasForeignKey(p => p.BlogForeignKey);
            // modelBuilder.Entity<ParaConfigTable>()
            // .HasKey(c => c.Id);

            // modelBuilder.Entity<ParaConfigDataId>()
            // .HasOne(s => s.table)
            // .WithMany(c => c.DataIds)
            // .HasForeignKey(s => s.Id);
            
            // modelBuilder.Entity<ParaConfigDataId>().HasNoKey();

            // modelBuilder.Entity<ParaConfigDataId>()
            // .HasOne(p => p.table)
            // .WithMany(b => b.DataIds)
            // .HasForeignKey(p => p.No);

            // modelBuilder.Entity<ParaConfigTable>().HasKey(p => p.No);
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParaConfigTable>(entity =>
            {
                entity.HasKey(e => e.Name);
                entity.Property(e => e.Name).IsRequired();
                // entity.HasMany(e => e.DataIds).WithOne();
            });
            modelBuilder.Entity<ParaConfigDataId>(entity =>
            {
                entity.HasOne(p => p.table)
                      .WithMany(b => b.DataIds)
                      .HasForeignKey(p => p.ConfigTableName);
                entity.HasKey(e => new {e.ConfigTableName, e.Id, e.DataArray});
                // entity.Property(e => e.Format).IsRequired();
                entity.Property(e => e.DataBytes).IsRequired();
                entity.Property(e => e.DataArray).IsRequired();
                // entity.Property(e => e.Unit).IsRequired();
                entity.Property(e => e.IsReadable).IsRequired();
                entity.Property(e => e.IsWritable).IsRequired();

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.GroupName).IsRequired();
            });
        }
        static public ParaConfigTableDbContext GetParaConfigTableDbContextInstance()
        {
            return paraConfigTableDbContext;
        }
    }
}
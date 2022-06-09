using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite.DataIdConfig;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.SQLite
{
    public class MeterTestDbContext : DbContext
    {
        private readonly string connectionString = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MeterTest\\MeterTestDb.db";
        public DbSet<MeterTestConfig> MeterTestConfigs{get; set;}
        public DbSet<Dlt645Server> Dlt645Servers{get; set;}
        public DbSet<Project> Projects { get; set; }
        public DbSet<DataIdTable> DataIdTables { get; set; }
        public DbSet<DataId> DataIds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString);
        public MeterTestDbContext() : base()
        {
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MeterTest"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MeterTest");
            }
            this.Database.Migrate();;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterTestConfig>(entity =>
            {
                entity.HasKey(e => e.Name);
                entity.Property(e => e.SelectReadProjectName).IsRequired(); 
                entity.Property(e => e.SelectReadTableName).IsRequired();  
                entity.Property(e => e.SelectWriteProjectName).IsRequired();   
                entity.Property(e => e.SelectWriteTableName).IsRequired();    
                entity.Property(e => e.SelectParaProjectName).IsRequired();   
                entity.Property(e => e.SelectParaTableName).IsRequired();      
                entity.Property(e => e.PortName).IsRequired();
                entity.Property(e => e.BaudRate).IsRequired();
                entity.Property(e => e.DataBits).IsRequired();
                entity.Property(e => e.Parity).IsRequired();
                entity.Property(e => e.StopBits).IsRequired();
                entity.Property(e => e.ReadTimeout).IsRequired();
                entity.Property(e => e.ActivationCode).IsRequired();
                entity.Property(e => e.MachineCode).IsRequired();
                entity.Property(e => e.TableBodySerialPortName).IsRequired();
            });
            modelBuilder.Entity<Dlt645Server>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Authority).IsRequired();
                entity.Property(e => e.OperatorCode).IsRequired();
                entity.Ignore(e => e.MeterAddress);
                entity.Ignore(e => e.Dlt645Password);
                entity.Ignore(e => e.Dlt645OperatorCode);
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Name);
                entity.Property(e => e.Id);
                entity.Property(e => e.IsUse);
                entity.Property(e => e.Ticks);
            });
            modelBuilder.Entity<DataIdTable>(entity =>
            {
                entity.HasKey(e => new {e.Name, e.IsConfig, e.ProjectName});
                entity.Property(e => e.Ticks);
                // entity.Property(e => e.DataIdList);
            });
            modelBuilder.Entity<DataId>(entity =>
            {
                entity.Property<string>("ForeignKey_DataIdTableName");
                entity.Property<bool>("ForeignKey_DataIdTableIsConfig");
                entity.Property<string>("ForeignKey_DataIdTableProjectName");
                entity.HasKey("ForeignKey_DataIdTableName", "ForeignKey_DataIdTableIsConfig", "ForeignKey_DataIdTableProjectName", "Id", "Name");
                entity.Property(e => e.GroupName);
                entity.Property(e => e.IsReadable);
                entity.Property(e => e.IsWritable);
                entity.Property(e => e.Unit);
                entity.Property(e => e.DataArray);
                entity.Property(e => e.DataBytes);
                entity.Property(e => e.Format);
            });
            modelBuilder.Entity<DataId>()
            .HasOne<DataIdTable>()
            .WithMany()
            .HasForeignKey("ForeignKey_DataIdTableName", "ForeignKey_DataIdTableIsConfig", "ForeignKey_DataIdTableProjectName");
            // modelBuilder.Entity<DataId>().HasAlternateKey("ForeignKey_DataIdTableName", "ForeignKey_DataIdTableIsConfig", "ForeignKey_DataIdTableProjectName");

            modelBuilder.Entity<DataIdTable>()
            .HasOne<Project>()
            .WithMany()
            .HasForeignKey("ProjectName");

            modelBuilder.Entity<Project>()
            .HasOne<MeterTestConfig>()
            .WithMany()
            .HasForeignKey("ForeignKey_Project");
        }

        public static Dlt645Server GetDlt645Server()
        {
            Dlt645Server dlt645Service = null;
            using (var context = new MeterTestDbContext())
            {
                dlt645Service = context.Dlt645Servers.AsNoTracking().FirstOrDefault();
                if(dlt645Service == null)
                {
                    dlt645Service = new Dlt645Server();
                    context.Dlt645Servers.Add(dlt645Service);
                    context.SaveChanges();
                }
                dlt645Service = context.Dlt645Servers.AsNoTracking().FirstOrDefault();
            }
            return dlt645Service;
        }
        public static MeterTestConfig GetMeterTestConfig()
        {
            MeterTestConfig meterTestConfig = null;
            using (var context = new MeterTestDbContext())
            {
                meterTestConfig = context.MeterTestConfigs.AsNoTracking().FirstOrDefault();
                if(meterTestConfig == null)
                {
                    meterTestConfig = new MeterTestConfig();
                    context.MeterTestConfigs.Add(meterTestConfig);
                    context.SaveChanges();
                }
                meterTestConfig = context.MeterTestConfigs.AsNoTracking().FirstOrDefault();
            }
            return meterTestConfig;
        }
        

        public static Project GetProject(string name)
        {
            Project project = null;
            using (var context = new MeterTestDbContext())
            {
                project = context.Projects.SingleOrDefault(e => e.Name == name);
            }
            return project;
        }
        public static Project GetRwProject(string name)
        {
            Project project = null;
            using (var context = new MeterTestDbContext())
            {
                project = context.Projects.SingleOrDefault(e => e.Name == name);
            }
            return project;
        }
        public static Project[] GetProjectArray()
        {
            Project[] projects = null;
            using (var context = new MeterTestDbContext())
            {
                projects = context.Projects.AsNoTracking().ToArray();
            }
            return projects;
        }
        public static List<DataId> GetDataIdList(string projectName, string tableName, bool isConfig)
        {
            List<DataId> dataIdList = null;
            using (var context = new MeterTestDbContext())
            {
                dataIdList = context.DataIds.AsNoTracking()
                                                  .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
                                                  .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                                  .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                                  .ToList();
            }
            return dataIdList;
        }
        public static bool DataIdTableContains(string projectName, string tableName, bool isConfig)
        {
            bool rst = false;
            using (var context = new MeterTestDbContext())
            {
                rst = context.DataIdTables.AsNoTracking()
                                          .Where(e => e.ProjectName == projectName)
                                          .Where(e => e.Name == tableName)
                                          .SingleOrDefault(e => e.IsConfig == isConfig) != null;
            }
            return rst;
        }
        public static List<DataIdTable> GetParaConfigTables(string projectName)
        {
            List<DataIdTable> DataIdTables = null;
            using (var context = new MeterTestDbContext())
            {
                DataIdTables = context.DataIdTables.Where(e => e.ProjectName == projectName)
                                                   .Where(e => e.IsConfig == true)
                                                   .AsNoTracking()
                                                   .ToList();
            }
            return DataIdTables;
        }
        public static List<DataIdTable> GetDataIdTableList(string projectName, bool IsConfig)
        {
            List<DataIdTable> DataIdTables = null;
            using (var context = new MeterTestDbContext())
            {
                DataIdTables = context.DataIdTables.Where(e => e.ProjectName == projectName)
                                                   .Where(e => e.IsConfig == IsConfig)
                                                   .AsNoTracking()
                                                   .ToList();
            }
            return DataIdTables;
        }
        public static List<DataIdTable> GetRwDataIdTables(string projectName)
        {
            List<DataIdTable> RwDataIdTables = null;
            using (var context = new MeterTestDbContext())
            {
                RwDataIdTables = context.DataIdTables.Where(e => e.ProjectName == projectName)
                                                   .Where(e => e.IsConfig == false)
                                                   .AsNoTracking()
                                                   .ToList();
            }
            return RwDataIdTables;
        }
        


        public static DataId GetDataId(string projectName, string tableName, bool isConfig, uint id)
        {
            DataId dataId = null;
            using (var context = new MeterTestDbContext())
            {
                dataId = context.DataIds.AsNoTracking()
                                        .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
                                        .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                        .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                        .Single(e => e.Id == id);
            }
            return dataId;
        }
        public static bool CheckDataId(string projectName, string tableName, bool isConfig, uint id)
        {
            DataId dataId = null;
            using (var context = new MeterTestDbContext())
            {
                dataId = context.DataIds.AsNoTracking()
                                        .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
                                        .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                        .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                        .SingleOrDefault(e => e.Id == id);
            }
            return dataId != null;
        }
    }
}
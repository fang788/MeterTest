using MeterTest.Source.Dlt645;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterTest.Source.SQLite
{
    public class DataIdDbContext : DbContext
    {
        public DbSet<DataId> DataIds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=DataIdList.db");


        
    }
}

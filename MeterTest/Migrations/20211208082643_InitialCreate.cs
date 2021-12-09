using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataIds",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    DataBytes = table.Column<int>(type: "INTEGER", nullable: false),
                    DataArray = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWritable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    GroupName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataIds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataIds");
        }
    }
}

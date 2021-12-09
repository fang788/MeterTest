using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.Migrations.ParaConfigTableDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParaConfigTables",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaConfigTables", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DataIds",
                columns: table => new
                {
                    DataArray = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Id = table.Column<uint>(type: "INTEGER", nullable: false),
                    ConfigTableName = table.Column<string>(type: "TEXT", nullable: true),
                    ParaConfigTableName = table.Column<string>(type: "TEXT", nullable: true),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    DataBytes = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWritable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataIds", x => new { x.Id, x.DataArray });
                    table.ForeignKey(
                        name: "FK_DataIds_ParaConfigTables_ParaConfigTableName",
                        column: x => x.ParaConfigTableName,
                        principalTable: "ParaConfigTables",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataIds_ParaConfigTableName",
                table: "DataIds",
                column: "ParaConfigTableName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataIds");

            migrationBuilder.DropTable(
                name: "ParaConfigTables");
        }
    }
}

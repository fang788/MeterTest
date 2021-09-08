using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.MigrationDirectory1
{
    public partial class migration_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomizationTables",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DataId",
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
                    GroupName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomizationTableName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataId_CustomizationTables_CustomizationTableName",
                        column: x => x.CustomizationTableName,
                        principalTable: "CustomizationTables",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataId_CustomizationTableName",
                table: "DataId",
                column: "CustomizationTableName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataId");

            migrationBuilder.DropTable(
                name: "CustomizationTables");
        }
    }
}

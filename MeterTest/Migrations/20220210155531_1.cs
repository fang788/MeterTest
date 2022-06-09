using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dlt645Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<long>(type: "INTEGER", nullable: false),
                    Authority = table.Column<byte>(type: "INTEGER", nullable: false),
                    OperatorCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Password = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlt645Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterTestConfigs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ActivationCode = table.Column<string>(type: "TEXT", nullable: false),
                    BaudRate = table.Column<int>(type: "INTEGER", nullable: false),
                    DataBits = table.Column<int>(type: "INTEGER", nullable: false),
                    MachineCode = table.Column<string>(type: "TEXT", nullable: false),
                    Parity = table.Column<int>(type: "INTEGER", nullable: false),
                    PortName = table.Column<string>(type: "TEXT", nullable: false),
                    ReadTimeout = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectParaProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    SelectParaTableName = table.Column<string>(type: "TEXT", nullable: false),
                    SelectReadProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    SelectReadTableName = table.Column<string>(type: "TEXT", nullable: false),
                    StopBits = table.Column<int>(type: "INTEGER", nullable: false),
                    TableBodySerialPortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterTestConfigs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "TableBodys",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBodys", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<uint>(type: "INTEGER", nullable: false),
                    IsUse = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ticks = table.Column<long>(type: "INTEGER", nullable: false),
                    ForeignKey_Project = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Projects_MeterTestConfigs_ForeignKey_Project",
                        column: x => x.ForeignKey_Project,
                        principalTable: "MeterTestConfigs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataIdTables",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsConfig = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Ticks = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataIdTables", x => new { x.Name, x.IsConfig, x.ProjectName });
                    table.ForeignKey(
                        name: "FK_DataIdTables_Projects_ProjectName",
                        column: x => x.ProjectName,
                        principalTable: "Projects",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataIds",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<uint>(type: "INTEGER", nullable: false),
                    ForeignKey_DataIdTableName = table.Column<string>(type: "TEXT", nullable: false),
                    ForeignKey_DataIdTableIsConfig = table.Column<bool>(type: "INTEGER", nullable: false),
                    ForeignKey_DataIdTableProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    DataBytes = table.Column<int>(type: "INTEGER", nullable: false),
                    DataArray = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWritable = table.Column<bool>(type: "INTEGER", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataIds", x => new { x.ForeignKey_DataIdTableName, x.ForeignKey_DataIdTableIsConfig, x.ForeignKey_DataIdTableProjectName, x.Id, x.Name });
                    table.ForeignKey(
                        name: "FK_DataIds_DataIdTables_ForeignKey_DataIdTableName_ForeignKey_DataIdTableIsConfig_ForeignKey_DataIdTableProjectName",
                        columns: x => new { x.ForeignKey_DataIdTableName, x.ForeignKey_DataIdTableIsConfig, x.ForeignKey_DataIdTableProjectName },
                        principalTable: "DataIdTables",
                        principalColumns: new[] { "Name", "IsConfig", "ProjectName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataIdTables_ProjectName",
                table: "DataIdTables",
                column: "ProjectName");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ForeignKey_Project",
                table: "Projects",
                column: "ForeignKey_Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataIds");

            migrationBuilder.DropTable(
                name: "Dlt645Services");

            migrationBuilder.DropTable(
                name: "TableBodys");

            migrationBuilder.DropTable(
                name: "DataIdTables");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "MeterTestConfigs");
        }
    }
}

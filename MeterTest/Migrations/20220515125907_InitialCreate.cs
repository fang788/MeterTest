using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dlt645Services");

            migrationBuilder.DropTable(
                name: "TableBodys");

            migrationBuilder.CreateTable(
                name: "Dlt645Servers",
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
                    table.PrimaryKey("PK_Dlt645Servers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dlt645Servers");

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
        }
    }
}

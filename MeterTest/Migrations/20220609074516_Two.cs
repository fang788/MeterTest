using Microsoft.EntityFrameworkCore.Migrations;

namespace MeterTest.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectWriteProjectName",
                table: "MeterTestConfigs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectWriteTableName",
                table: "MeterTestConfigs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectWriteProjectName",
                table: "MeterTestConfigs");

            migrationBuilder.DropColumn(
                name: "SelectWriteTableName",
                table: "MeterTestConfigs");
        }
    }
}

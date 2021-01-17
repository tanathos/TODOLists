using Microsoft.EntityFrameworkCore.Migrations;

namespace TODO.Api.Migrations
{
    public partial class OtherFieldsTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "Todos");
        }
    }
}

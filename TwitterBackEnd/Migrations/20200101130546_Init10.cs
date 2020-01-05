using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccCreatedOn",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccCreatedOn",
                table: "User");
        }
    }
}

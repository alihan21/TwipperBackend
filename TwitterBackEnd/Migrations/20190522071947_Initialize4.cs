using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Initialize4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_Retweets_RetweetId1",
                table: "Retweets");

            migrationBuilder.DropIndex(
                name: "IX_Retweets_RetweetId1",
                table: "Retweets");

            migrationBuilder.DropColumn(
                name: "RetweetId1",
                table: "Retweets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetweetId1",
                table: "Retweets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Retweets_RetweetId1",
                table: "Retweets",
                column: "RetweetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_Retweets_RetweetId1",
                table: "Retweets",
                column: "RetweetId1",
                principalTable: "Retweets",
                principalColumn: "RetweetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_User_UserId",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tweets",
                newName: "PostedById");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                newName: "IX_Tweets_PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_User_PostedById",
                table: "Tweets",
                column: "PostedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_User_PostedById",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "PostedById",
                table: "Tweets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_PostedById",
                table: "Tweets",
                newName: "IX_Tweets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_User_UserId",
                table: "Tweets",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

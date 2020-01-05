using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_User_GebruikerId",
                table: "Retweets");

            migrationBuilder.RenameColumn(
                name: "TweetDate",
                table: "Tweets",
                newName: "BaseTweetDate");

            migrationBuilder.RenameColumn(
                name: "TweetId",
                table: "Tweets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TweetDate",
                table: "Retweets",
                newName: "BaseTweetDate");

            migrationBuilder.RenameColumn(
                name: "GebruikerId",
                table: "Retweets",
                newName: "PostedById");

            migrationBuilder.RenameColumn(
                name: "RetweetId",
                table: "Retweets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Retweets_GebruikerId",
                table: "Retweets",
                newName: "IX_Retweets_PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_User_PostedById",
                table: "Retweets",
                column: "PostedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_User_PostedById",
                table: "Retweets");

            migrationBuilder.RenameColumn(
                name: "BaseTweetDate",
                table: "Tweets",
                newName: "TweetDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tweets",
                newName: "TweetId");

            migrationBuilder.RenameColumn(
                name: "PostedById",
                table: "Retweets",
                newName: "GebruikerId");

            migrationBuilder.RenameColumn(
                name: "BaseTweetDate",
                table: "Retweets",
                newName: "TweetDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Retweets",
                newName: "RetweetId");

            migrationBuilder.RenameIndex(
                name: "IX_Retweets_PostedById",
                table: "Retweets",
                newName: "IX_Retweets_GebruikerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_User_GebruikerId",
                table: "Retweets",
                column: "GebruikerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Initialize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweet_Gebruiker_GebruikerId",
                table: "Retweet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Retweet",
                table: "Retweet");

            migrationBuilder.RenameTable(
                name: "Retweet",
                newName: "Retweets");

            migrationBuilder.RenameIndex(
                name: "IX_Retweet_GebruikerId",
                table: "Retweets",
                newName: "IX_Retweets_GebruikerId");

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "Retweets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Retweets",
                table: "Retweets",
                column: "RetweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Retweets_TweetId",
                table: "Retweets",
                column: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_Gebruiker_GebruikerId",
                table: "Retweets",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_Tweets_TweetId",
                table: "Retweets",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "TweetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_Gebruiker_GebruikerId",
                table: "Retweets");

            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_Tweets_TweetId",
                table: "Retweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Retweets",
                table: "Retweets");

            migrationBuilder.DropIndex(
                name: "IX_Retweets_TweetId",
                table: "Retweets");

            migrationBuilder.RenameTable(
                name: "Retweets",
                newName: "Retweet");

            migrationBuilder.RenameIndex(
                name: "IX_Retweets_GebruikerId",
                table: "Retweet",
                newName: "IX_Retweet_GebruikerId");

            migrationBuilder.AlterColumn<int>(
                name: "TweetId",
                table: "Retweet",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Retweet",
                table: "Retweet",
                column: "RetweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweet_Gebruiker_GebruikerId",
                table: "Retweet",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

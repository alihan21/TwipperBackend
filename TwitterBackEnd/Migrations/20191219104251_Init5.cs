using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Gebruiker_GebruikerId",
                table: "Tweets");

            migrationBuilder.DropTable(
                name: "GevolgdenEnVolgersTussentabel");

            migrationBuilder.RenameColumn(
                name: "TweetDatum",
                table: "Tweets",
                newName: "TweetDate");

            migrationBuilder.RenameColumn(
                name: "GebruikerId",
                table: "Tweets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Boodschap",
                table: "Tweets",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_GebruikerId",
                table: "Tweets",
                newName: "IX_Tweets_UserId");

            migrationBuilder.RenameColumn(
                name: "TweetDatum",
                table: "Retweets",
                newName: "TweetDate");

            migrationBuilder.RenameColumn(
                name: "Boodschap",
                table: "Retweets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "VolledigeNaam",
                table: "Gebruiker",
                newName: "FullName");

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    FollowerId = table.Column<string>(nullable: false),
                    FollowingId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_Connections_Gebruiker_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connections_Gebruiker_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_FollowingId",
                table: "Connections",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Gebruiker_UserId",
                table: "Tweets",
                column: "UserId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Gebruiker_UserId",
                table: "Tweets");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tweets",
                newName: "GebruikerId");

            migrationBuilder.RenameColumn(
                name: "TweetDate",
                table: "Tweets",
                newName: "TweetDatum");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tweets",
                newName: "Boodschap");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                newName: "IX_Tweets_GebruikerId");

            migrationBuilder.RenameColumn(
                name: "TweetDate",
                table: "Retweets",
                newName: "TweetDatum");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Retweets",
                newName: "Boodschap");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Gebruiker",
                newName: "VolledigeNaam");

            migrationBuilder.CreateTable(
                name: "GevolgdenEnVolgersTussentabel",
                columns: table => new
                {
                    VolgerId = table.Column<string>(nullable: false),
                    GevolgdeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GevolgdenEnVolgersTussentabel", x => new { x.VolgerId, x.GevolgdeId });
                    table.ForeignKey(
                        name: "FK_GevolgdenEnVolgersTussentabel_Gebruiker_GevolgdeId",
                        column: x => x.GevolgdeId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GevolgdenEnVolgersTussentabel_Gebruiker_VolgerId",
                        column: x => x.VolgerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GevolgdenEnVolgersTussentabel_GevolgdeId",
                table: "GevolgdenEnVolgersTussentabel",
                column: "GevolgdeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Gebruiker_GebruikerId",
                table: "Tweets",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

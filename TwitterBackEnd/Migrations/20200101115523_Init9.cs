using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterBackEnd.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BaseTweetDate",
                table: "Tweets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "BaseTweetDate",
                table: "Retweets",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BaseTweetDate",
                table: "Tweets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BaseTweetDate",
                table: "Retweets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

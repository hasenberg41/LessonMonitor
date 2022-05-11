using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class AddColumnMembersYoutube : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeAccountId",
                table: "Members",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Homeworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_MemberId",
                table: "Homeworks",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Members_MemberId",
                table: "Homeworks",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Members_MemberId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_MemberId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "YoutubeAccountId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Homeworks");
        }
    }
}

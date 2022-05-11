using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class UpdateMemberColumn_YoutubeAccountIdOnYoutubeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Members_YoutubeAccountId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "YoutubeAccountId",
                table: "Members",
                newName: "YoutubeUserId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Members_YoutubeUserId",
                table: "Members",
                column: "YoutubeUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Members_YoutubeUserId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "YoutubeUserId",
                table: "Members",
                newName: "YoutubeAccountId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Members_YoutubeAccountId",
                table: "Members",
                column: "YoutubeAccountId");
        }
    }
}

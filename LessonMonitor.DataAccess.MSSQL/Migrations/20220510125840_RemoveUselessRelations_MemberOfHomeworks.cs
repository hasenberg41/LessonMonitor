using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class RemoveUselessRelations_MemberOfHomeworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Members_MemberId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_MemberId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Homeworks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

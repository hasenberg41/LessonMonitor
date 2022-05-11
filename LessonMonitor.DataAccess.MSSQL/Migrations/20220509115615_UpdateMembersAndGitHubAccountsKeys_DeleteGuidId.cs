using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class UpdateMembersAndGitHubAccountsKeys_DeleteGuidId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_GitHubAccounts_GitHubAccountId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_GitHubAccountId",
                table: "Members");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GitHubAccounts_MemberId",
                table: "GitHubAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GitHubAccounts",
                table: "GitHubAccounts");

            migrationBuilder.DropColumn(
                name: "GitHubAccountId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GitHubAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GitHubAccounts",
                table: "GitHubAccounts",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_GitHubAccounts_Members_MemberId",
                table: "GitHubAccounts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GitHubAccounts_Members_MemberId",
                table: "GitHubAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GitHubAccounts",
                table: "GitHubAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "GitHubAccountId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "GitHubAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GitHubAccounts_MemberId",
                table: "GitHubAccounts",
                column: "MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GitHubAccounts",
                table: "GitHubAccounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GitHubAccountId",
                table: "Members",
                column: "GitHubAccountId",
                unique: true,
                filter: "[GitHubAccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_GitHubAccounts_GitHubAccountId",
                table: "Members",
                column: "GitHubAccountId",
                principalTable: "GitHubAccounts",
                principalColumn: "Id");
        }
    }
}

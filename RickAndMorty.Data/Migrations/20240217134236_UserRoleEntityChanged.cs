﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickAndMorty.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleEntityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_UserRoleId");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserRoles",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRoles",
                newName: "RoleName");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalStoreManagementSystem.Migrations
{
    public partial class Foreignkeyupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDetailsModels_rolesModels_RolesModelRoleId",
                table: "userDetailsModels");

            migrationBuilder.DropIndex(
                name: "IX_userDetailsModels_RolesModelRoleId",
                table: "userDetailsModels");

            migrationBuilder.DropColumn(
                name: "RolesModelRoleId",
                table: "userDetailsModels");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "userDetailsModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "userDetailsModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "userDetailsModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userDetailsModels_RoleId",
                table: "userDetailsModels",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_userDetailsModels_rolesModels_RoleId",
                table: "userDetailsModels",
                column: "RoleId",
                principalTable: "rolesModels",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDetailsModels_rolesModels_RoleId",
                table: "userDetailsModels");

            migrationBuilder.DropIndex(
                name: "IX_userDetailsModels_RoleId",
                table: "userDetailsModels");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "userDetailsModels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "userDetailsModels");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "userDetailsModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesModelRoleId",
                table: "userDetailsModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userDetailsModels_RolesModelRoleId",
                table: "userDetailsModels",
                column: "RolesModelRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_userDetailsModels_rolesModels_RolesModelRoleId",
                table: "userDetailsModels",
                column: "RolesModelRoleId",
                principalTable: "rolesModels",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

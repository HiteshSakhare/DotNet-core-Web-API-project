using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalStoreManagementSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loginModels",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "rolesModels",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesModels", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "userDetailsModels",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    RolesModelRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetailsModels", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_userDetailsModels_rolesModels_RolesModelRoleId",
                        column: x => x.RolesModelRoleId,
                        principalTable: "rolesModels",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userDetailsModels_RolesModelRoleId",
                table: "userDetailsModels",
                column: "RolesModelRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loginModels");

            migrationBuilder.DropTable(
                name: "userDetailsModels");

            migrationBuilder.DropTable(
                name: "rolesModels");
        }
    }
}

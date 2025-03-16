using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserOnwerId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserOnwerId",
                        column: x => x.UserOnwerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    GroupPermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_GroupPermissions_GroupPermissionId",
                        column: x => x.GroupPermissionId,
                        principalTable: "GroupPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TaskApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedId = table.Column<int>(type: "int", nullable: false),
                    UserResponsibleId = table.Column<int>(type: "int", nullable: false),
                    StatusTaskId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PriorityTask = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskApps_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskApps_StatusTasks_StatusTaskId",
                        column: x => x.StatusTaskId,
                        principalTable: "StatusTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskApps_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskApps_Users_UserResponsibleId",
                        column: x => x.UserResponsibleId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "GroupPermissions",
                columns: new[] { "Id", "IsAdmin", "Name" },
                values: new object[,]
                {
                    { 1, true, "Admin" },
                    { 2, false, "Membro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserOnwerId",
                table: "Projects",
                column: "UserOnwerId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTasks_ProjectId",
                table: "StatusTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskApps_ProjectId",
                table: "TaskApps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskApps_StatusTaskId",
                table: "TaskApps",
                column: "StatusTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskApps_UserCreatedId",
                table: "TaskApps",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskApps_UserResponsibleId",
                table: "TaskApps",
                column: "UserResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_GroupPermissionId",
                table: "UserProjects",
                column: "GroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskApps");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "StatusTasks");

            migrationBuilder.DropTable(
                name: "GroupPermissions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

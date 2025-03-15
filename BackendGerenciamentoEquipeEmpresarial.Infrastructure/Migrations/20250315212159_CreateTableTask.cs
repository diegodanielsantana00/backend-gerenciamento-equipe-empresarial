using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTasks", x => x.Id);
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
                    PriorityTask = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskApps_StatusTasks_StatusTaskId",
                        column: x => x.StatusTaskId,
                        principalTable: "StatusTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskApps_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskApps_Users_UserResponsibleId",
                        column: x => x.UserResponsibleId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskApps");

            migrationBuilder.DropTable(
                name: "StatusTasks");
        }
    }
}

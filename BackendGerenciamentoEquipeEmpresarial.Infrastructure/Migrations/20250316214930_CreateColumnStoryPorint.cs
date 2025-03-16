using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendGerenciamentoEquipeEmpresarial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnStoryPorint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoryPoints",
                table: "TaskApps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryPoints",
                table: "TaskApps");
        }
    }
}

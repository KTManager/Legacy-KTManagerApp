using Microsoft.EntityFrameworkCore.Migrations;

namespace KillTeam.Migrations
{
    public partial class AddTeamMaxPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxPoints",
                table: "Teams",
                nullable: false,
                defaultValue: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPoints",
                table: "Teams");
        }
    }
}

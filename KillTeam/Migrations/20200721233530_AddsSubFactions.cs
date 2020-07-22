using Microsoft.EntityFrameworkCore.Migrations;

namespace KillTeam.Migrations
{
    public partial class AddsSubFactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubFactionId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubFaction",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    FactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubFaction_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_SubFactionId",
                table: "Members",
                column: "SubFactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFaction_FactionId",
                table: "SubFaction",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_SubFaction_SubFactionId",
                table: "Members",
                column: "SubFactionId",
                principalTable: "SubFaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_SubFaction_SubFactionId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "SubFaction");

            migrationBuilder.DropIndex(
                name: "IX_Members_SubFactionId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SubFactionId",
                table: "Members");
        }
    }
}

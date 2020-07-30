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
                name: "SubFactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    FactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubFactions_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberSubFactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    SubFactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSubFactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberSubFactions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberSubFactions_SubFactions_SubFactionId",
                        column: x => x.SubFactionId,
                        principalTable: "SubFactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelProfileSubFaction",
                columns: table => new
                {
                    ModelProfileId = table.Column<string>(nullable: false),
                    SubFactionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProfileSubFaction", x => new { x.ModelProfileId, x.SubFactionId });
                    table.ForeignKey(
                        name: "FK_ModelProfileSubFaction_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelProfileSubFaction_SubFactions_SubFactionId",
                        column: x => x.SubFactionId,
                        principalTable: "SubFactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_SubFactionId",
                table: "Members",
                column: "SubFactionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSubFactions_MemberId",
                table: "MemberSubFactions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSubFactions_SubFactionId",
                table: "MemberSubFactions",
                column: "SubFactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelProfileSubFaction_SubFactionId",
                table: "ModelProfileSubFaction",
                column: "SubFactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFactions_FactionId",
                table: "SubFactions",
                column: "FactionId");

            /*
             *  Since SQLite does not support ALTER TABLE statements that
             *  add Foreign Keys, we need to create a table with the new schema,
             *  migrate all existing data over to that table, drop the original
             *  table, and rename the new table as the original one.
             *  
             *  This approach is documented here:
             *  https://github.com/dotnet/efcore/issues/329#issuecomment-276138743
             */
            migrationBuilder.CreateTable(
                name: "tmp_Members",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelProfileId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TeamId = table.Column<string>(nullable: true),
                    SpecialistId = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Xp = table.Column<int>(nullable: false),
                    Selected = table.Column<bool>(nullable: false),
                    FleshWounds = table.Column<int>(nullable: false),
                    Convalescence = table.Column<bool>(nullable: false),
                    Recruit = table.Column<bool>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    SubFactionId = table.Column<int>(nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_SubFaction_SubFactionId",
                        column: x => x.SubFactionId,
                        principalTable: "SubFactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                }
            );
            migrationBuilder.Sql("INSERT INTO tmp_Members SELECT * FROM Members;");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            migrationBuilder.Sql("DROP TABLE Members", true);
            migrationBuilder.Sql("ALTER TABLE tmp_Members RENAME TO Members", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_SubFactions_SubFactionId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "MemberSubFactions");

            migrationBuilder.DropTable(
                name: "ModelProfileSubFaction");

            migrationBuilder.DropTable(
                name: "SubFactions");

            migrationBuilder.DropIndex(
                name: "IX_Members_SubFactionId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SubFactionId",
                table: "Members");
        }
    }
}

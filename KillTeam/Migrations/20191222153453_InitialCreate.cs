using Microsoft.EntityFrameworkCore.Migrations;

namespace KillTeam.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RulesVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    KeywordsEn = table.Column<string>(nullable: true),
                    KeywordsFr = table.Column<string>(nullable: true),
                    KeywordsDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Roster = table.Column<bool>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    PreviewsId = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    SpecialistId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Powers_Powers_PreviewsId",
                        column: x => x.PreviewsId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Powers_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeaponProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    Range = table.Column<int>(nullable: false),
                    ShotNumber = table.Column<string>(nullable: true),
                    Strength = table.Column<string>(nullable: true),
                    ArmourPenetration = table.Column<string>(nullable: true),
                    Damages = table.Column<string>(nullable: true),
                    WeaponId = table.Column<string>(nullable: true),
                    WeaponTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponProfiles_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponProfiles_WeaponTypes_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelId = table.Column<string>(nullable: true),
                    Movement = table.Column<int>(nullable: false),
                    WeaponSkill = table.Column<int>(nullable: false),
                    BallisticSkill = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Toughness = table.Column<int>(nullable: false),
                    Wounds = table.Column<int>(nullable: false),
                    Attacks = table.Column<string>(nullable: true),
                    Leadership = table.Column<int>(nullable: false),
                    Save = table.Column<int>(nullable: false),
                    MaximumNumber = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    IsCommander = table.Column<bool>(nullable: false),
                    NumberOfKnownPsychics = table.Column<int>(nullable: false),
                    NumberOfPsychicsManifestationPerRound = table.Column<int>(nullable: false),
                    NumberOfPsychicsDenialPerRound = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelProfiles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelWeapon",
                columns: table => new
                {
                    ModelId = table.Column<string>(nullable: false),
                    WeaponId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelWeapon", x => new { x.ModelId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_ModelWeapon_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelWeapon_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    ModelId = table.Column<string>(nullable: true),
                    ModelProfileId = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Abilities_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Abilities_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostOverride",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelProfileId = table.Column<string>(nullable: true),
                    WeaponId = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOverride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostOverride_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostOverride_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelCost",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    ModelProfileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelCost_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
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
                    Cost = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "ModelProfileSpecialist",
                columns: table => new
                {
                    ModelProfileId = table.Column<string>(nullable: false),
                    SpecialistId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProfileSpecialist", x => new { x.ModelProfileId, x.SpecialistId });
                    table.ForeignKey(
                        name: "FK_ModelProfileSpecialist_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelProfileSpecialist_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelProfileWeapon",
                columns: table => new
                {
                    ModelProfileId = table.Column<string>(nullable: false),
                    WeaponId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProfileWeapon", x => new { x.ModelProfileId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_ModelProfileWeapon_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelProfileWeapon_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Psychics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelProfileId = table.Column<string>(nullable: true),
                    WarpCharge = table.Column<int>(nullable: false),
                    Dices = table.Column<int>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    Commander = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychics_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tactics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FactionId = table.Column<string>(nullable: true),
                    SpecialistId = table.Column<string>(nullable: true),
                    ModelProfileId = table.Column<string>(nullable: true),
                    PhaseId = table.Column<string>(nullable: true),
                    Aura = table.Column<bool>(nullable: false),
                    Commander = table.Column<bool>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tactics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tactics_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tactics_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tactics_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tactics_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ModelProfileId = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    NameEn = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    NameDe = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traits_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarGearOption",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MaximumPerTeam = table.Column<int>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    Exclusion = table.Column<string>(nullable: true),
                    ModelProfileId = table.Column<string>(nullable: true),
                    ModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarGearOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarGearOption_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarGearOption_ModelProfiles_ModelProfileId",
                        column: x => x.ModelProfileId,
                        principalTable: "ModelProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbilityDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AbilityId = table.Column<string>(nullable: true),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false),
                    ContentEn = table.Column<string>(nullable: true),
                    ContentFr = table.Column<string>(nullable: true),
                    ContentDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityDetail_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberPowers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MembrerId = table.Column<string>(nullable: true),
                    PowerId = table.Column<string>(nullable: true),
                    IsGeneral = table.Column<bool>(nullable: false),
                    IsMaster = table.Column<bool>(nullable: false),
                    MemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberPowers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembreArme",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WeaponId = table.Column<string>(nullable: true),
                    MemberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembreArme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembreArme_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembreArme_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberPsychics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    PsychicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPsychics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberPsychics_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPsychics_Psychics_PsychicId",
                        column: x => x.PsychicId,
                        principalTable: "Psychics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberTraits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    TraitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTraits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberTraits_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberTraits_Traits_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberWarGearOptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MemberId = table.Column<string>(nullable: true),
                    WarGearOptionId = table.Column<string>(nullable: true),
                    WeaponId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWarGearOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberWarGearOptions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberWarGearOptions_WarGearOption_WarGearOptionId",
                        column: x => x.WarGearOptionId,
                        principalTable: "WarGearOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberWarGearOptions_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_FactionId",
                table: "Abilities",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_ModelId",
                table: "Abilities",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_ModelProfileId",
                table: "Abilities",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityDetail_AbilityId",
                table: "AbilityDetail",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CostOverride_ModelProfileId",
                table: "CostOverride",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CostOverride_WeaponId",
                table: "CostOverride",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelCost_ModelProfileId",
                table: "LevelCost",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPowers_MemberId",
                table: "MemberPowers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPowers_PowerId",
                table: "MemberPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPsychics_MemberId",
                table: "MemberPsychics",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPsychics_PsychicId",
                table: "MemberPsychics",
                column: "PsychicId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ModelProfileId",
                table: "Members",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_SpecialistId",
                table: "Members",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTraits_MemberId",
                table: "MemberTraits",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTraits_TraitId",
                table: "MemberTraits",
                column: "TraitId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWarGearOptions_MemberId",
                table: "MemberWarGearOptions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWarGearOptions_WarGearOptionId",
                table: "MemberWarGearOptions",
                column: "WarGearOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberWarGearOptions_WeaponId",
                table: "MemberWarGearOptions",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_MembreArme_MemberId",
                table: "MembreArme",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembreArme_WeaponId",
                table: "MembreArme",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelProfiles_ModelId",
                table: "ModelProfiles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelProfileSpecialist_SpecialistId",
                table: "ModelProfileSpecialist",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelProfileWeapon_WeaponId",
                table: "ModelProfileWeapon",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_FactionId",
                table: "Models",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelWeapon_WeaponId",
                table: "ModelWeapon",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Powers_PreviewsId",
                table: "Powers",
                column: "PreviewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Powers_SpecialistId",
                table: "Powers",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychics_ModelProfileId",
                table: "Psychics",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_FactionId",
                table: "Tactics",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_ModelProfileId",
                table: "Tactics",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_PhaseId",
                table: "Tactics",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tactics_SpecialistId",
                table: "Tactics",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FactionId",
                table: "Teams",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Traits_ModelProfileId",
                table: "Traits",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WarGearOption_ModelId",
                table: "WarGearOption",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WarGearOption_ModelProfileId",
                table: "WarGearOption",
                column: "ModelProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponProfiles_WeaponId",
                table: "WeaponProfiles",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponProfiles_WeaponTypeId",
                table: "WeaponProfiles",
                column: "WeaponTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityDetail");

            migrationBuilder.DropTable(
                name: "CostOverride");

            migrationBuilder.DropTable(
                name: "LevelCost");

            migrationBuilder.DropTable(
                name: "MemberPowers");

            migrationBuilder.DropTable(
                name: "MemberPsychics");

            migrationBuilder.DropTable(
                name: "MemberTraits");

            migrationBuilder.DropTable(
                name: "MemberWarGearOptions");

            migrationBuilder.DropTable(
                name: "MembreArme");

            migrationBuilder.DropTable(
                name: "ModelProfileSpecialist");

            migrationBuilder.DropTable(
                name: "ModelProfileWeapon");

            migrationBuilder.DropTable(
                name: "ModelWeapon");

            migrationBuilder.DropTable(
                name: "Tactics");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "WeaponProfiles");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Psychics");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "WarGearOption");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "ModelProfiles");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}

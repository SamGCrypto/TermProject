using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Handler",
                columns: table => new
                {
                    HandlerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandlerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handler", x => x.HandlerId);
                });

            migrationBuilder.CreateTable(
                name: "MonsterTypes",
                columns: table => new
                {
                    MonsterTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterTypes", x => x.MonsterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterCount = table.Column<int>(type: "int", nullable: false),
                    MonsterThreatLvl = table.Column<int>(type: "int", nullable: false),
                    MonsterTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeMonsterTypeId = table.Column<int>(type: "int", nullable: true),
                    TypeDescriptionMonsterTypeId = table.Column<int>(type: "int", nullable: true),
                    HandlerId = table.Column<int>(type: "int", nullable: false),
                    HandlerNameHandlerId = table.Column<int>(type: "int", nullable: true),
                    HandlerDescriptionHandlerId = table.Column<int>(type: "int", nullable: true),
                    HandlerTypeHandlerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Handler_HandlerDescriptionHandlerId",
                        column: x => x.HandlerDescriptionHandlerId,
                        principalTable: "Handler",
                        principalColumn: "HandlerId");
                    table.ForeignKey(
                        name: "FK_Monsters_Handler_HandlerId",
                        column: x => x.HandlerId,
                        principalTable: "Handler",
                        principalColumn: "HandlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monsters_Handler_HandlerNameHandlerId",
                        column: x => x.HandlerNameHandlerId,
                        principalTable: "Handler",
                        principalColumn: "HandlerId");
                    table.ForeignKey(
                        name: "FK_Monsters_Handler_HandlerTypeHandlerId",
                        column: x => x.HandlerTypeHandlerId,
                        principalTable: "Handler",
                        principalColumn: "HandlerId");
                    table.ForeignKey(
                        name: "FK_Monsters_MonsterTypes_MonsterTypeId",
                        column: x => x.MonsterTypeId,
                        principalTable: "MonsterTypes",
                        principalColumn: "MonsterTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monsters_MonsterTypes_TypeDescriptionMonsterTypeId",
                        column: x => x.TypeDescriptionMonsterTypeId,
                        principalTable: "MonsterTypes",
                        principalColumn: "MonsterTypeId");
                    table.ForeignKey(
                        name: "FK_Monsters_MonsterTypes_TypeMonsterTypeId",
                        column: x => x.TypeMonsterTypeId,
                        principalTable: "MonsterTypes",
                        principalColumn: "MonsterTypeId");
                });

            migrationBuilder.InsertData(
                table: "Handler",
                columns: new[] { "HandlerId", "HandlerDescription", "HandlerName", "HandlerType" },
                values: new object[,]
                {
                    { 1, "Starman", "David Bowie", "Cosmic" },
                    { 2, "Queen", "Mercury, Freddy", "Royal" },
                    { 3, "Toons", "Tom and Jerry", "Toon physics specialist" }
                });

            migrationBuilder.InsertData(
                table: "MonsterTypes",
                columns: new[] { "MonsterTypeId", "Type", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "Holy", "Holy type arcana, typically former priests of religion." },
                    { 2, "Cosmic", "Usually Celestial being, usually requires space travel to fight" },
                    { 3, "Infernal", "These entities usually are from hell or have a connection to it." }
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "HandlerDescriptionHandlerId", "HandlerId", "HandlerNameHandlerId", "HandlerTypeHandlerId", "MonsterCount", "MonsterName", "MonsterThreatLvl", "MonsterTypeId", "TypeDescriptionMonsterTypeId", "TypeMonsterTypeId" },
                values: new object[,]
                {
                    { 1, null, 2, null, null, 1, "Mothman", 3, 2, null, null },
                    { 2, null, 1, null, null, 2, "Kaiju", 5, 3, null, null },
                    { 3, null, 3, null, null, 201, "Poltergeist", 2, 1, null, null },
                    { 4, null, 3, null, null, 999, "Grim Grinning Ghosts Gang", 1, 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_HandlerDescriptionHandlerId",
                table: "Monsters",
                column: "HandlerDescriptionHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_HandlerId",
                table: "Monsters",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_HandlerNameHandlerId",
                table: "Monsters",
                column: "HandlerNameHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_HandlerTypeHandlerId",
                table: "Monsters",
                column: "HandlerTypeHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_MonsterTypeId",
                table: "Monsters",
                column: "MonsterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_TypeDescriptionMonsterTypeId",
                table: "Monsters",
                column: "TypeDescriptionMonsterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_TypeMonsterTypeId",
                table: "Monsters",
                column: "TypeMonsterTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Handler");

            migrationBuilder.DropTable(
                name: "MonsterTypes");
        }
    }
}

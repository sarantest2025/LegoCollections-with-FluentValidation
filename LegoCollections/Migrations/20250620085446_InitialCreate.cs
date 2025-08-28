using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoCollections.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegoLists",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_LegoLists", static x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegoFigures",
                columns: static table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrickLinkCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: static table =>
                {
                    table.PrimaryKey("PK_LegoFigures", static x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegoFigures_LegoLists_ListId",
                        column: static x => x.ListId,
                        principalTable: "LegoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegoFigures_ListId",
                table: "LegoFigures",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegoFigures");

            migrationBuilder.DropTable(
                name: "LegoLists");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoCollections.Migrations
{
    /// <inheritdoc />
    public partial class AddLegoListIdToYourTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegoFigures_LegoLists_ListId",
                table: "LegoFigures");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "LegoFigures",
                newName: "LegoListId");

            migrationBuilder.RenameIndex(
                name: "IX_LegoFigures_ListId",
                table: "LegoFigures",
                newName: "IX_LegoFigures_LegoListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LegoFigures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "LegoFigures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LegoFigures_LegoLists_LegoListId",
                table: "LegoFigures",
                column: "LegoListId",
                principalTable: "LegoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegoFigures_LegoLists_LegoListId",
                table: "LegoFigures");

            migrationBuilder.RenameColumn(
                name: "LegoListId",
                table: "LegoFigures",
                newName: "ListId");

            migrationBuilder.RenameIndex(
                name: "IX_LegoFigures_LegoListId",
                table: "LegoFigures",
                newName: "IX_LegoFigures_ListId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LegoFigures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "LegoFigures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_LegoFigures_LegoLists_ListId",
                table: "LegoFigures",
                column: "ListId",
                principalTable: "LegoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

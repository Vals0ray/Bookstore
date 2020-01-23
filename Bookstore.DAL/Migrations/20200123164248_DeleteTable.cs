using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.DAL.Migrations
{
    public partial class DeleteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDimensions");

            migrationBuilder.AddColumn<float>(
                name: "Long",
                table: "BookDetails",
                maxLength: 8,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tall",
                table: "BookDetails",
                maxLength: 8,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Wide",
                table: "BookDetails",
                maxLength: 8,
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Long",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "Tall",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "Wide",
                table: "BookDetails");

            migrationBuilder.CreateTable(
                name: "BookDimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookDetailsId = table.Column<int>(type: "int", nullable: false),
                    Long = table.Column<float>(type: "real", maxLength: 8, nullable: false),
                    Tall = table.Column<float>(type: "real", maxLength: 8, nullable: false),
                    Wide = table.Column<float>(type: "real", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookDimensions_BookDetails_BookDetailsId",
                        column: x => x.BookDetailsId,
                        principalTable: "BookDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookDimensions_BookDetailsId",
                table: "BookDimensions",
                column: "BookDetailsId",
                unique: true);
        }
    }
}

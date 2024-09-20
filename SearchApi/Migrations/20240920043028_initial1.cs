using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchApi.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductDetailsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BestSellerRankId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BestSellerRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestSellerRanks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailsId",
                table: "Products",
                column: "ProductDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_BestSellerRankId",
                table: "ProductDetails",
                column: "BestSellerRankId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_BestSellerRanks_BestSellerRankId",
                table: "ProductDetails",
                column: "BestSellerRankId",
                principalTable: "BestSellerRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailsId",
                table: "Products",
                column: "ProductDetailsId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_BestSellerRanks_BestSellerRankId",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BestSellerRanks");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailsId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_BestSellerRankId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductDetailsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "BestSellerRankId",
                table: "ProductDetails");
        }
    }
}

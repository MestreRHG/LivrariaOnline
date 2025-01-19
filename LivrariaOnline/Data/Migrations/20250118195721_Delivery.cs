using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaOnline.Data.Migrations
{
    /// <inheritdoc />
    public partial class Delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Deliveries",
                newName: "BookBoughtId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_BookBoughtId",
                table: "Deliveries",
                column: "BookBoughtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Books_BookBoughtId",
                table: "Deliveries",
                column: "BookBoughtId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Books_BookBoughtId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_BookBoughtId",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "BookBoughtId",
                table: "Deliveries",
                newName: "BookId");
        }
    }
}

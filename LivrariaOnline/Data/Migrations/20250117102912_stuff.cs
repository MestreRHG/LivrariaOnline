using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaOnline.Data.Migrations
{
    /// <inheritdoc />
    public partial class stuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimensions",
                table: "Books",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Editor",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Editor",
                table: "Books");
        }
    }
}

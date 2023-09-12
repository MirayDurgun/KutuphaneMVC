using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseModelIsDeletedEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Yazarlar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "YayinEvleri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kitaplar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Yazarlar");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "YayinEvleri");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kitaplar");
        }
    }
}

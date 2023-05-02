using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadin.Cms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteFeature_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactMessages");
        }
    }
}

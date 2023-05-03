using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadin.Cms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditableProperties_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ContactMessages");
        }
    }
}

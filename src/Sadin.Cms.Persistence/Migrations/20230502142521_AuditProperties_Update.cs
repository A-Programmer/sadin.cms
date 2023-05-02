using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadin.Cms.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditProperties_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ContactMessages",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ContactMessages",
                newName: "CreatedOnUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "ContactMessages",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "ContactMessages",
                newName: "CreatedDate");
        }
    }
}

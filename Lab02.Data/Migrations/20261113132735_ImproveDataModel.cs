using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab02.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImproveDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DatasetVersions_DatasetId",
                table: "DatasetVersions");

            migrationBuilder.CreateIndex(
                name: "IX_Researchers_Email",
                table: "Researchers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatasetVersions_DatasetId_VersionNumber",
                table: "DatasetVersions",
                columns: new[] { "DatasetId", "VersionNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Researchers_Email",
                table: "Researchers");

            migrationBuilder.DropIndex(
                name: "IX_DatasetVersions_DatasetId_VersionNumber",
                table: "DatasetVersions");

            migrationBuilder.CreateIndex(
                name: "IX_DatasetVersions_DatasetId",
                table: "DatasetVersions",
                column: "DatasetId");
        }
    }
}

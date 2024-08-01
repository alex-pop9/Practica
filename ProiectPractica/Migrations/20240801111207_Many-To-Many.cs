using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Paths",
                newName: "FileSettingsID");

            migrationBuilder.RenameColumn(
                name: "idPath",
                table: "PathConfigurationLog",
                newName: "FileSettingsID");

            migrationBuilder.RenameColumn(
                name: "idConfiguration",
                table: "PathConfigurationLog",
                newName: "ConfigurationLogID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PathConfigurationLog",
                newName: "PathConfigurationLogID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ConfigurationLog",
                newName: "ConfigurationLogID");

            migrationBuilder.CreateIndex(
                name: "IX_PathConfigurationLog_ConfigurationLogID",
                table: "PathConfigurationLog",
                column: "ConfigurationLogID");

            migrationBuilder.CreateIndex(
                name: "IX_PathConfigurationLog_FileSettingsID",
                table: "PathConfigurationLog",
                column: "FileSettingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_PathConfigurationLog_ConfigurationLog_ConfigurationLogID",
                table: "PathConfigurationLog",
                column: "ConfigurationLogID",
                principalTable: "ConfigurationLog",
                principalColumn: "ConfigurationLogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PathConfigurationLog_Paths_FileSettingsID",
                table: "PathConfigurationLog",
                column: "FileSettingsID",
                principalTable: "Paths",
                principalColumn: "FileSettingsID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PathConfigurationLog_ConfigurationLog_ConfigurationLogID",
                table: "PathConfigurationLog");

            migrationBuilder.DropForeignKey(
                name: "FK_PathConfigurationLog_Paths_FileSettingsID",
                table: "PathConfigurationLog");

            migrationBuilder.DropIndex(
                name: "IX_PathConfigurationLog_ConfigurationLogID",
                table: "PathConfigurationLog");

            migrationBuilder.DropIndex(
                name: "IX_PathConfigurationLog_FileSettingsID",
                table: "PathConfigurationLog");

            migrationBuilder.RenameColumn(
                name: "FileSettingsID",
                table: "Paths",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FileSettingsID",
                table: "PathConfigurationLog",
                newName: "idPath");

            migrationBuilder.RenameColumn(
                name: "ConfigurationLogID",
                table: "PathConfigurationLog",
                newName: "idConfiguration");

            migrationBuilder.RenameColumn(
                name: "PathConfigurationLogID",
                table: "PathConfigurationLog",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ConfigurationLogID",
                table: "ConfigurationLog",
                newName: "id");
        }
    }
}

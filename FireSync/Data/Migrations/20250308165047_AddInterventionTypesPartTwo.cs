using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInterventionTypesPartTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_interventions_intervention_type_intervention_type_id",
                table: "interventions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_intervention_type",
                table: "intervention_type");

            migrationBuilder.RenameTable(
                name: "intervention_type",
                newName: "intervention_types");

            migrationBuilder.AddPrimaryKey(
                name: "pk_intervention_types",
                table: "intervention_types",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_interventions_intervention_types_intervention_type_id",
                table: "interventions",
                column: "intervention_type_id",
                principalTable: "intervention_types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_interventions_intervention_types_intervention_type_id",
                table: "interventions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_intervention_types",
                table: "intervention_types");

            migrationBuilder.RenameTable(
                name: "intervention_types",
                newName: "intervention_type");

            migrationBuilder.AddPrimaryKey(
                name: "pk_intervention_type",
                table: "intervention_type",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_interventions_intervention_type_intervention_type_id",
                table: "interventions",
                column: "intervention_type_id",
                principalTable: "intervention_type",
                principalColumn: "id");
        }
    }
}

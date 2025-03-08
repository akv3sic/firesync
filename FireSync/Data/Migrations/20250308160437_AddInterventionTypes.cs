using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInterventionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "intervention_type_id",
                table: "interventions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "intervention_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    color_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_intervention_type", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_interventions_intervention_type_id",
                table: "interventions",
                column: "intervention_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_interventions_intervention_type_intervention_type_id",
                table: "interventions",
                column: "intervention_type_id",
                principalTable: "intervention_type",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_interventions_intervention_type_intervention_type_id",
                table: "interventions");

            migrationBuilder.DropTable(
                name: "intervention_type");

            migrationBuilder.DropIndex(
                name: "ix_interventions_intervention_type_id",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "intervention_type_id",
                table: "interventions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInterventionAndApplicationUserIntervention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "interventions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interventions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_user_interventions",
                columns: table => new
                {
                    intervention_id = table.Column<Guid>(type: "uuid", nullable: false),
                    application_user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_user_interventions", x => new { x.intervention_id, x.application_user_id });
                    table.ForeignKey(
                        name: "fk_application_user_interventions_interventions_intervention_id",
                        column: x => x.intervention_id,
                        principalTable: "interventions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_application_user_interventions_users_application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_application_user_interventions_application_user_id",
                table: "application_user_interventions",
                column: "application_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_user_interventions");

            migrationBuilder.DropTable(
                name: "interventions");
        }
    }
}

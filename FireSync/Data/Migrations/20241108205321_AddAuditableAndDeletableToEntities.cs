using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableAndDeletableToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "vehicles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "vehicles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "vehicle_registrations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "vehicle_registrations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "vehicle_registrations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "vehicle_registrations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "vehicle_registrations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "vehicle_registrations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "interventions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "interventions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "interventions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "interventions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "interventions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "interventions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "vehicle_registrations");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "interventions");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "AspNetUsers");
        }
    }
}

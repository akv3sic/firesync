using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateYearOfManufactureToShort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE vehicles ALTER COLUMN year_of_manufacture TYPE smallint USING EXTRACT(YEAR FROM year_of_manufacture)::smallint;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "year_of_manufacture",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}

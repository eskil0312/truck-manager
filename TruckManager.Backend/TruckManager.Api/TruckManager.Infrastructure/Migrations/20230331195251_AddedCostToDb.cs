using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCostToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost_Amount",
                table: "TruckTankings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Cost_Currency",
                table: "TruckTankings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost_Amount",
                table: "TruckTankings");

            migrationBuilder.DropColumn(
                name: "Cost_Currency",
                table: "TruckTankings");
        }
    }
}

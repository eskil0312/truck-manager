using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TruckTankings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "TruckTankings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

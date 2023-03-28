using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelTankSize = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeichleAllowenceExperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TruckIncidents",
                columns: table => new
                {
                    TruckIncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckIncidents", x => new { x.TruckIncidentId, x.TruckId });
                    table.ForeignKey(
                        name: "FK_TruckIncidents_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruckTankings",
                columns: table => new
                {
                    TruckTankingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantiy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckTankings", x => new { x.TruckTankingId, x.TruckId });
                    table.ForeignKey(
                        name: "FK_TruckTankings_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckIncidents_TruckId",
                table: "TruckIncidents",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckTankings_TruckId",
                table: "TruckTankings",
                column: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckIncidents");

            migrationBuilder.DropTable(
                name: "TruckTankings");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}

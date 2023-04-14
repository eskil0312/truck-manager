using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Companies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTruckIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyTruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTruckIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTruckIds_Companies_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUserIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUserIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUserIds_Companies_UserId",
                        column: x => x.UserId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTruckIds_TruckId",
                table: "CompanyTruckIds",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUserIds_UserId",
                table: "CompanyUserIds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTruckIds");

            migrationBuilder.DropTable(
                name: "CompanyUserIds");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TokenDateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AccessToken = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireInsuranceLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TotalArea = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    AppliancesValue = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    AreaUnitPriceId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EstateTypeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StructureTypeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CoverageIds = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireInsuranceLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireReqLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LogDateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    JsonReq = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PublicAppId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ServiceId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PublicReqId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireReqLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireResLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ResCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HTTPStatusCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    JsonRes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PublicReqId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReqLogId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CarTollsReqLogId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireResLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireResLogs_FireReqLogs_CarTollsReqLogId",
                        column: x => x.CarTollsReqLogId,
                        principalTable: "FireReqLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireResLogs_CarTollsReqLogId",
                table: "FireResLogs",
                column: "CarTollsReqLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTokens");

            migrationBuilder.DropTable(
                name: "FireInsuranceLogs");

            migrationBuilder.DropTable(
                name: "FireResLogs");

            migrationBuilder.DropTable(
                name: "FireReqLogs");
        }
    }
}

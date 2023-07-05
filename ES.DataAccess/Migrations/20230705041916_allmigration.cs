using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FloorNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftFunctionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentPostion = table.Column<int>(type: "int", nullable: false),
                    EmergencyAlarm = table.Column<bool>(type: "bit", nullable: false),
                    Fan = table.Column<bool>(type: "bit", nullable: false),
                    FireAlarm = table.Column<bool>(type: "bit", nullable: false),
                    PowerStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftFunctionDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetailsInLifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromFloorNum = table.Column<int>(type: "int", nullable: false),
                    ToFloorNum = table.Column<int>(type: "int", nullable: false),
                    TravelledDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetailsInLifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "LiftFunctionDetail");

            migrationBuilder.DropTable(
                name: "PersonDetailsInLifts");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

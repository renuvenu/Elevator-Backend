using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Persondetails_timeadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TravelledDateTime",
                table: "PersonDetailsInLifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelledDateTime",
                table: "PersonDetailsInLifts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity_API.Migrations
{
    /// <inheritdoc />
    public partial class donation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LeftoverAmount",
                table: "Donations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftoverAmount",
                table: "Donations");
        }
    }
}

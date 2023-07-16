using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity_API.Migrations
{
    /// <inheritdoc />
    public partial class notes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Donation_Benefitiary_Id",
                table: "User_Donators_Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Donation_Benefitiary_Id",
                table: "User_Donators_Notes");
        }
    }
}

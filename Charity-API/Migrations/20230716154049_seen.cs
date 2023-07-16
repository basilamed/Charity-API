using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity_API.Migrations
{
    /// <inheritdoc />
    public partial class seen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "User_Donators_Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "User_Donators_Notes");
        }
    }
}

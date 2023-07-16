using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity_API.Migrations
{
    /// <inheritdoc />
    public partial class note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Donators_Notes_Notes_NoteId",
                table: "User_Donators_Notes");

            migrationBuilder.DropIndex(
                name: "IX_User_Donators_Notes_NoteId",
                table: "User_Donators_Notes");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "User_Donators_Notes");

            migrationBuilder.CreateIndex(
                name: "IX_User_Donators_Notes_NodeId",
                table: "User_Donators_Notes",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Donators_Notes_Notes_NodeId",
                table: "User_Donators_Notes",
                column: "NodeId",
                principalTable: "Notes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Donators_Notes_Notes_NodeId",
                table: "User_Donators_Notes");

            migrationBuilder.DropIndex(
                name: "IX_User_Donators_Notes_NodeId",
                table: "User_Donators_Notes");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "User_Donators_Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Donators_Notes_NoteId",
                table: "User_Donators_Notes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Donators_Notes_Notes_NoteId",
                table: "User_Donators_Notes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

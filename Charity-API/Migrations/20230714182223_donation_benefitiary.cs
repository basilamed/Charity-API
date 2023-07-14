using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity_API.Migrations
{
    /// <inheritdoc />
    public partial class donation_benefitiary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courier_Donation_Benefitiaries");

            migrationBuilder.CreateTable(
                name: "Donation_Benefitiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationId = table.Column<int>(type: "int", nullable: false),
                    BenefitiaryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation_Benefitiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_Benefitiaries_AspNetUsers_BenefitiaryId",
                        column: x => x.BenefitiaryId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donation_Benefitiaries_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donation_Benefitiaries_BenefitiaryId",
                table: "Donation_Benefitiaries",
                column: "BenefitiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_Benefitiaries_DonationId",
                table: "Donation_Benefitiaries",
                column: "DonationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation_Benefitiaries");

            migrationBuilder.CreateTable(
                name: "Courier_Donation_Benefitiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitiaryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier_Donation_Benefitiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courier_Donation_Benefitiaries_AspNetUsers_BenefitiaryId",
                        column: x => x.BenefitiaryId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courier_Donation_Benefitiaries_AspNetUsers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courier_Donation_Benefitiaries_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courier_Donation_Benefitiaries_BenefitiaryId",
                table: "Courier_Donation_Benefitiaries",
                column: "BenefitiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courier_Donation_Benefitiaries_CourierId",
                table: "Courier_Donation_Benefitiaries",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Courier_Donation_Benefitiaries_DonationId",
                table: "Courier_Donation_Benefitiaries",
                column: "DonationId");
        }
    }
}

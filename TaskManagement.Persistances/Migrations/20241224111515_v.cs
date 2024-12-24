using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistances.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatuses",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatuses", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactPerson = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: true),
                    ContactNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    MailID = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AddClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    GSTNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    ClientStatusCode = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    CountryCode = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    StateCode = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    CityCode = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddClients_Cities_CityCode",
                        column: x => x.CityCode,
                        principalTable: "Cities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddClients_ClientStatuses_ClientStatusCode",
                        column: x => x.ClientStatusCode,
                        principalTable: "ClientStatuses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddClients_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddClients_States_StateCode",
                        column: x => x.StateCode,
                        principalTable: "States",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddClients_CityCode",
                table: "AddClients",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddClients_ClientStatusCode",
                table: "AddClients",
                column: "ClientStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddClients_CountryCode",
                table: "AddClients",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddClients_StateCode",
                table: "AddClients",
                column: "StateCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddClients");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ClientStatuses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}

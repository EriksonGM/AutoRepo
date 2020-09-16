using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRepo.Data.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailAccounts",
                columns: table => new
                {
                    IdMailAccount = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UseSSL = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAccounts", x => x.IdMailAccount);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    IdReport = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Boby = table.Column<string>(nullable: true),
                    IsHtml = table.Column<bool>(nullable: false),
                    IdMailAccount = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.IdReport);
                    table.ForeignKey(
                        name: "FK_Reports_MailAccounts_IdMailAccount",
                        column: x => x.IdMailAccount,
                        principalTable: "MailAccounts",
                        principalColumn: "IdMailAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinies",
                columns: table => new
                {
                    IdDestiny = table.Column<Guid>(nullable: false),
                    IdReport = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinies", x => x.IdDestiny);
                    table.ForeignKey(
                        name: "FK_Destinies_Reports_IdReport",
                        column: x => x.IdReport,
                        principalTable: "Reports",
                        principalColumn: "IdReport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinies_IdReport",
                table: "Destinies",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_IdMailAccount",
                table: "Reports",
                column: "IdMailAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinies");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "MailAccounts");
        }
    }
}

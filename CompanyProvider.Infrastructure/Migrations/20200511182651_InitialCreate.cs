using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyProvider.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FantasyName = table.Column<string>(nullable: false),
                    Uf = table.Column<int>(nullable: false),
                    Cnpj = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProvider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PersonType = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(nullable: true),
                    CpfCnpj = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProvider_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(nullable: false),
                    CompanyProviderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_CompanyProvider_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProvider_CompanyId",
                table: "CompanyProvider",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyProviderId",
                table: "Contact",
                column: "CompanyProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CompanyProvider");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}

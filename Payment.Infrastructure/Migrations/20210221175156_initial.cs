using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreditCardNumber = table.Column<string>(nullable: false),
                    CardHolder = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPayments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionPayments");
        }
    }
}

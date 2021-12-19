using Microsoft.EntityFrameworkCore.Migrations;

namespace NextensTaxTool.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientFinancialData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Income = table.Column<long>(type: "bigint", nullable: true),
                    RealEstatePropertyValue = table.Column<long>(type: "bigint", nullable: true),
                    BankBalanceNational = table.Column<long>(type: "bigint", nullable: true),
                    BankbalanceInternational = table.Column<long>(type: "bigint", nullable: true),
                    StockInvestments = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFinancialData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFinancialData");
        }
    }
}

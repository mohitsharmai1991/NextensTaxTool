using NextensTaxTool.BLL;
using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using NUnit.Framework;

namespace NextensTaxTool.Tests
{
    public class TaxIndicatorsServiceTests
    {
        private ITaxIndicatorsService _taxIndicatorsService;
        [SetUp]
        public void Setup()
        {
            _taxIndicatorsService = new TaxIndicatorsService();
        }

        [Test]
        public void WealthTaxIndicator_Present()
        {
            var clientData =
                new ClientFinancialData()
                {
                    Id = "test1",
                    ClientId = "testClient1",
                    Year = 2020,
                    Income = 2000,
                    BankbalanceInternational = 2000,
                    BankBalanceNational = 2000,
                    RealEstatePropertyValue = 40000,
                    StockInvestments = 200000
                };

            var expected = new WealthTaxViewModel() { TotalCapital = 204000 };

            var result = _taxIndicatorsService.GetWealthTaxIndicator(clientData);

            Assert.AreEqual(expected.TotalCapital, result.TotalCapital);
        }
    }
}
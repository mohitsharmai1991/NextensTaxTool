using NextensTaxTool.BLL;
using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NextensTaxTool.Tests
{
    public class IncomeIndicatorsServiceTests
    {
        private IIncomeIndicatorsService _incomeIndicatorsService;
        [SetUp]
        public void Setup()
        {
            _incomeIndicatorsService = new IncomeIndicatorsService();
        }

        [Test]
        public void IncomeVolatilityIndicator_Present()
        {
            var clientDataList = new List<ClientFinancialData>()
            {
                new ClientFinancialData(){ Id="test1",ClientId="testClient1",
                Year=2020,Income=2000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=2000,StockInvestments=2000},
               new ClientFinancialData(){ Id="test2",ClientId="testClient2",
                Year=2019,Income=4000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=2000,StockInvestments=2000}
            };

            var expected = new IncomeViewModel() { Income = 2000, PercentageChange = 50, PreviousYear = 2019, Year = 2020 };

            var result = _incomeIndicatorsService.GetIncomeVolatilityIndicator(clientDataList, 2020);

            Assert.AreEqual(expected.Income, result.Income);
            Assert.AreEqual(expected.PercentageChange, result.PercentageChange);
            Assert.AreEqual(expected.PreviousYear, result.PreviousYear);
            Assert.AreEqual(expected.Year, result.Year);
        }
    }
}
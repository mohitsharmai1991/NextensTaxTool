using NextensTaxTool.BLL;
using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NextensTaxTool.Tests
{
    public class PropertyIndicatorsServiceTests
    {
        private IPropertyIndicatorsService _propertyIndicatorsService;

        [SetUp]
        public void Setup()
        {
            _propertyIndicatorsService = new PropertyIndicatorsService();
        }

        [Test]
        public void PropertyValueGrowthIndicator_Present()
        {
            var clientDataList = new List<ClientFinancialData>()
            {
                new ClientFinancialData(){ Id="test1",ClientId="testClient1",
                Year=2020,Income=2000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=16000,StockInvestments=2000},
               new ClientFinancialData(){ Id="test2",ClientId="testClient2",
                Year=2019,Income=4000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=8000,StockInvestments=2000},
                      new ClientFinancialData(){ Id="test3",ClientId="testClient3",
                Year=2018,Income=4000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=4000,StockInvestments=2000},
                              new ClientFinancialData(){ Id="test4",ClientId="testClient4",
                Year=2017,Income=4000,BankbalanceInternational=2000,BankBalanceNational=2000,RealEstatePropertyValue=2000,StockInvestments=2000}
            };

            var expected = new PropertyValueViewModel() { PercentageGainOverLastThreeYears = 700, TotalValue = 16000 };

            var result = _propertyIndicatorsService.GetPropertyValueIndicator(clientDataList, 2020);

            Assert.AreEqual(expected.PercentageGainOverLastThreeYears, result.PercentageGainOverLastThreeYears);
            Assert.AreEqual(expected.TotalValue, result.TotalValue);
        }
    }
}
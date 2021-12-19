using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Models;
using System.Collections.Generic;
using System.Linq;

namespace NextensTaxTool.BLL
{
    public class ReportService : IReportService
    {
        private readonly INextensFinancialDataService _nextensFinancialDataService;
        private readonly ITaxIndicatorsService _taxIndicatorsService;
        private readonly IPropertyIndicatorsService _propertyIndicatorsService;
        private readonly IIncomeIndicatorsService _incomeIndicatorsService;

        public ReportService(INextensFinancialDataService nextensFinancialDataService, ITaxIndicatorsService taxIndicatorsService
            , IPropertyIndicatorsService propertyIndicatorsService, IIncomeIndicatorsService incomeIndicatorsService)
        {
            _nextensFinancialDataService = nextensFinancialDataService;
            _taxIndicatorsService = taxIndicatorsService;
            _propertyIndicatorsService = propertyIndicatorsService;
            _incomeIndicatorsService = incomeIndicatorsService;
        }

        /// <summary>
        /// Generate report for particular year
        /// </summary>
        /// <param name="year">Reporting year</param>
        /// <returns></returns>
        public List<ReportViewModel> GetReportForUniqueClients(int year)
        {
            var allClientsData = _nextensFinancialDataService.GetAllClientFinanacialData();
            var allClientIds = allClientsData.Select(x => x.ClientId).Distinct().ToList();
            var reportData = new List<ReportViewModel>();

            foreach (var clientId in allClientIds)
            {
                var report = new ReportViewModel();
                var wealthTaxIndicator = _taxIndicatorsService.GetWealthTaxIndicator(allClientsData.Where(x => x.ClientId.Equals(clientId) && x.Year == year).FirstOrDefault());
                var propertyValueGrowthIndicator = _propertyIndicatorsService.GetPropertyValueIndicator(allClientsData.Where(x => x.ClientId.Equals(clientId) && (x.Year == year || x.Year == year - 1 || x.Year == year - 2 || x.Year == year - 3)).ToList(), year);
                var incomeVolatilityIndicator = _incomeIndicatorsService.GetIncomeVolatilityIndicator(allClientsData.Where(x => x.ClientId.Equals(clientId) && (x.Year == year || x.Year == year - 1)).ToList(), year);
                var clientForYear = allClientsData.Where(x => x.ClientId.Equals(clientId) && x.Year == year).FirstOrDefault();
                if (wealthTaxIndicator != null || propertyValueGrowthIndicator != null || incomeVolatilityIndicator != null)
                {
                    report.WealthTaxViewModel = wealthTaxIndicator;
                    report.PropertyValueViewModel = propertyValueGrowthIndicator;
                    report.IncomeViewModel = incomeVolatilityIndicator;
                    report.TotalWealth = (clientForYear?.BankBalanceNational ?? 0) + (clientForYear?.BankbalanceInternational ?? 0) + (clientForYear?.RealEstatePropertyValue ?? 0) + (clientForYear?.Income ?? 0) + (clientForYear?.StockInvestments ?? 0);
                    report.ClientId = clientForYear?.ClientId;
                    reportData.Add(report);
                }
            }

            reportData = reportData.OrderByDescending(x => x.TotalWealth).ToList();
            return reportData;
        }
    }
}

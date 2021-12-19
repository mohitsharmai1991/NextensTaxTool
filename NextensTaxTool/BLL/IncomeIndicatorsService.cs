using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Common;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using System.Collections.Generic;

namespace NextensTaxTool.BLL
{
    public class IncomeIndicatorsService : IIncomeIndicatorsService
    {
        public IncomeViewModel GetIncomeVolatilityIndicator(List<ClientFinancialData> clientFinancialData, int year)
        {
            int year1 = year - 1;
            if (!General.IsChangedinComparedPercent(clientFinancialData.Find(x => x.Year == year1)?.Income ?? 0, clientFinancialData.Find(x => x.Year == year)?.Income ?? 0, Constant.IncomeChangePercent))
            {
                return null;
            }

            return new IncomeViewModel() { Income = clientFinancialData.Find(x => x.Year == year)?.Income ?? 0, PercentageChange = General.PercentChange(clientFinancialData.Find(x => x.Year == year1)?.Income ?? 0, clientFinancialData.Find(x => x.Year == year)?.Income ?? 0), PreviousYear = year1, Year = year };
        }
    }
}

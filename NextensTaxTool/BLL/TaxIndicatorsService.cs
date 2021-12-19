using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;

namespace NextensTaxTool.BLL
{
    public class TaxIndicatorsService : ITaxIndicatorsService
    {
        public WealthTaxViewModel GetWealthTaxIndicator(ClientFinancialData clientFinancialData)
        {
            var totalCapital = (clientFinancialData?.BankBalanceNational ?? 0) + (clientFinancialData?.BankbalanceInternational ?? 0) + (clientFinancialData?.StockInvestments ?? 0);

            if (totalCapital > 200000)
            {
                return new WealthTaxViewModel() { TotalCapital = totalCapital };
            }

            return null;
        }
    }
}

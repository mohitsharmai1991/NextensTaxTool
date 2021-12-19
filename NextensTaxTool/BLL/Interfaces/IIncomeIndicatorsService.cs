using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using System.Collections.Generic;

namespace NextensTaxTool.BLL.Interfaces
{
    /// <summary>
    /// For indicators specific to income
    /// </summary>
    public interface IIncomeIndicatorsService
    {
        public IncomeViewModel GetIncomeVolatilityIndicator(List<ClientFinancialData> clientFinancialData, int year);
    }
}

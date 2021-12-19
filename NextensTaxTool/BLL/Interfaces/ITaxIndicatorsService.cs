using NextensTaxTool.Entities;
using NextensTaxTool.Models;

namespace NextensTaxTool.BLL.Interfaces
{
    /// <summary>
    /// For indicators specific to tax
    /// </summary>
    public interface ITaxIndicatorsService
    {
        public WealthTaxViewModel GetWealthTaxIndicator(ClientFinancialData clientFinancialData);
    }
}

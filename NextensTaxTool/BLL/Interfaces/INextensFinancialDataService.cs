using NextensTaxTool.Entities;
using System.Linq;

namespace NextensTaxTool.BLL.Interfaces
{
    /// <summary>
    /// For financial data
    /// </summary>
    public interface INextensFinancialDataService
    {
        public IQueryable<ClientFinancialData> GetAllClientFinanacialData();
        public bool ImportData();
    }
}

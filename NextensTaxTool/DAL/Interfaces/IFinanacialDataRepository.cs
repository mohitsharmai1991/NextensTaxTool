using NextensTaxTool.Entities;
using System.Linq;

namespace NextensTaxTool.DAL.Interfaces
{
    /// <summary>
    /// Repository to contact database for financial data
    /// </summary>
    public interface IFinanacialDataRepository
    {
        public IQueryable<ClientFinancialData> GetAllClientFinanacialData();
        public void InsertClientFinanacialData(ClientFinancialData clientFinancialData);
    }
}

using NextensTaxTool.Context;
using NextensTaxTool.DAL.Interfaces;
using NextensTaxTool.Entities;
using System.Linq;

namespace NextensTaxTool.DAL
{
    public class FinanacialDataRepository : IFinanacialDataRepository
    {
        private readonly NextensDbContext _dbContext;
        public FinanacialDataRepository(NextensDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ClientFinancialData> GetAllClientFinanacialData()
        {
            return _dbContext.ClientFinancialData;
        }

        public int ClientFinancialDataCount(string id)
        {
            return _dbContext.ClientFinancialData.Where(x => x.Id.Equals(id)).Count();
        }

        public void InsertClientFinanacialData(ClientFinancialData clientFinancialData)
        {
            if (ClientFinancialDataCount(clientFinancialData.Id) == 0)
            {
                _dbContext.Add(clientFinancialData);
            }
            else
            {
                _dbContext.Update(clientFinancialData);
            }
            _dbContext.SaveChanges();
        }
    }
}

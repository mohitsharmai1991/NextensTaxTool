using NextensTaxTool.Models;
using System.Collections.Generic;

namespace NextensTaxTool.BLL.Interfaces
{
    /// <summary>
    /// For reporting
    /// </summary>
    public interface IReportService
    {
        public List<ReportViewModel> GetReportForUniqueClients(int year);
    }
}

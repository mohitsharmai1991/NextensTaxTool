using Newtonsoft.Json;
using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.DAL.Interfaces;
using NextensTaxTool.Entities;
using System;
using System.IO;
using System.Linq;

namespace NextensTaxTool.BLL
{
    public class NextensFinancialDataService : INextensFinancialDataService
    {
        private readonly IFinanacialDataRepository _finanacialDataRepository;

        public NextensFinancialDataService(IFinanacialDataRepository finanacialDataRepository)
        {
            _finanacialDataRepository = finanacialDataRepository;
        }

        public IQueryable<ClientFinancialData> GetAllClientFinanacialData()
        {
            return _finanacialDataRepository.GetAllClientFinanacialData();
        }

        public bool ImportData()
        {
            var result = true;
            try
            {
                string[] files = Directory.GetFiles("ImportData/");
                foreach (var file in files)
                {
                    using (StreamReader r = new StreamReader(file))
                    {
                        string json = r.ReadToEnd();
                        ClientFinancialData clientFinancialData = JsonConvert.DeserializeObject<ClientFinancialData>(json);
                        _finanacialDataRepository.InsertClientFinanacialData(clientFinancialData);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}

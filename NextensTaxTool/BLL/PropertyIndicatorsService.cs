using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Common;
using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using System.Collections.Generic;

namespace NextensTaxTool.BLL
{
    public class PropertyIndicatorsService : IPropertyIndicatorsService
    {
        public PropertyValueViewModel GetPropertyValueIndicator(List<ClientFinancialData> clientFinancialData, int year)
        {
            int year1 = year - 1, year2 = year - 2, year3 = year - 3;
            if (!General.IsChangedinComparedPercent(clientFinancialData.Find(x => x.Year == year1)?.RealEstatePropertyValue ?? 0, clientFinancialData.Find(x => x.Year == year)?.RealEstatePropertyValue ?? 0, Constant.PropertyChangePercent))
            {
                return null;
            }
            else if (!General.IsChangedinComparedPercent(clientFinancialData.Find(x => x.Year == year2)?.RealEstatePropertyValue ?? 0, clientFinancialData.Find(x => x.Year == year1)?.RealEstatePropertyValue ?? 0, Constant.PropertyChangePercent))
            {
                return null;
            }
            else if (!General.IsChangedinComparedPercent(clientFinancialData.Find(x => x.Year == year3)?.RealEstatePropertyValue ?? 0, clientFinancialData.Find(x => x.Year == year2)?.RealEstatePropertyValue ?? 0, Constant.PropertyChangePercent))
            {
                return null;
            }

            var properValueViewModel = new PropertyValueViewModel() { TotalValue = clientFinancialData.Find(x => x.Year == year)?.RealEstatePropertyValue ?? 0 };
            properValueViewModel.PercentageGainOverLastThreeYears = General.PercentChange(clientFinancialData.Find(x => x.Year == year3)?.RealEstatePropertyValue ?? 0, clientFinancialData.Find(x => x.Year == year)?.RealEstatePropertyValue ?? 0);
            return properValueViewModel;
        }

    }
}

using NextensTaxTool.Entities;
using NextensTaxTool.Models;
using System.Collections.Generic;

namespace NextensTaxTool.BLL.Interfaces
{
    /// <summary>
    /// For indicators specific to property/real estate
    /// </summary>
    public interface IPropertyIndicatorsService
    {
        public PropertyValueViewModel GetPropertyValueIndicator(List<ClientFinancialData> clientFinancialData, int year);
    }
}

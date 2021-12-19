namespace NextensTaxTool.Models
{
    public class ReportViewModel
    {
        public WealthTaxViewModel WealthTaxViewModel { get; set; }

        public PropertyValueViewModel PropertyValueViewModel { get; set; }
        public IncomeViewModel IncomeViewModel { get; set; }
        public long TotalWealth { get; set; }
        public string ClientId { get; set; }
    }
}

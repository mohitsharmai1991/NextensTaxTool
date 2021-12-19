namespace NextensTaxTool.Models
{
    public class IncomeViewModel
    {
        public int Year { get; set; }
        public int PreviousYear { get; set; }
        public long Income { get; set; }
        public double PercentageChange { get; set; }
    }
}

namespace NextensTaxTool.Entities
{
    public class ClientFinancialData
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public int Year { get; set; }
        public long? Income { get; set; }
        public long? RealEstatePropertyValue { get; set; }
        public long? BankBalanceNational { get; set; }
        public long? BankbalanceInternational { get; set; }
        public long? StockInvestments { get; set; }
    }
}

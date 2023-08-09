namespace Beekeeping.Models.Statistics
{   
    public class StatisticsViewModel
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalCost { get; set; }

        public decimal FinancialResult { get; set; }

        public int ApiariesCount { get; set; }

        public int BeeColoniesCount { get; set; }

        public double BeeColoniesAverageStrenght { get; set; }

    }
}
namespace SmartHomeAutomation.Models
{
    public class MonthlyEnergyReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public double TotalConsumption { get; set; } 
        public decimal TotalCost { get; set; }
    }
}

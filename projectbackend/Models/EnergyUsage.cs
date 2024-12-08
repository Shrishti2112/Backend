namespace SmartHomeAPI.Models
{
    public class EnergyUsage
    {
        public int UsageId { get; set; }
        public int DeviceId { get; set; }
        public double Consumption { get; set; } 
        public string TimePeriod { get; set; }   
        public decimal EnergyCost { get; set; }  
    }

}

namespace SmartHomeAPI.Models
{
    public class SecurityDevice
    {
        public int SecurityDeviceId { get; set; }
        public string Type { get; set; }             
        public string Status { get; set; }           
        public string Location { get; set; }         
        public string DetectionHistory { get; set; } 
        public string AlertStatus { get; set; }      
    }

}

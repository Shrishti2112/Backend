namespace SmartHomeAPI.Models
{
    public class Device
    {
        public int DeviceId { get; set; }              
        public string Name { get; set; }               
        public string Type { get; set; }               
        public string Location { get; set; }           
        public string Status { get; set; }            
        public string ConfigurationSettings { get; set; } 
        public DateTime LastUpdated { get; set; }     
        public int? RoomId { get; set; }
      
    }
}

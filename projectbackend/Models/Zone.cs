namespace SmartHomeAPI.Models
{
    public class Zone
    {
        public int ZoneId { get; set; } 
        public string Name { get; set; } 

       
        public ICollection<Room> Rooms { get; set; } 
    }
}

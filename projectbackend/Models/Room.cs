namespace SmartHomeAPI.Models
{
    using SmartHomeAPI.Models;

    public class Room
    {

        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int ZoneId { get; set; } 
    }
    public enum RoomType
    {
        LivingRoom,
        Kitchen,
        Bedroom,
        Bathroom,
        Hallway
        
    }
}
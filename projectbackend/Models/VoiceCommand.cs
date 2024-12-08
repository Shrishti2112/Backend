namespace SmartHomeAPI.Models
{
    public class VoiceCommand
    {
        public int CommandId { get; set; }
        public string CommandName { get; set; }
        public int DeviceId { get; set; } 
        public string Status { get; set; }
    }
}

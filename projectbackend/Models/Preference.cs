namespace SmartHomeAPI.Models
{
    public class Preference
    {
        public int PreferenceId { get; set; }
        public int UserId { get; set; } 
        public int DeviceId { get; set; } 
        public string SettingName { get; set; } 
        public string SettingValue { get; set; } 
        public string ProfileType { get; set; } 
    }
}

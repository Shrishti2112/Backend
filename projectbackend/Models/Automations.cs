namespace SmartHomeAPI.Models
{
    public class Automation
    {
        public int AutomationId { get; set; }        
        public int DeviceId { get; set; }             
        public string TriggerEvent { get; set; }      
        public string Action { get; set; }            
        public string TimeSchedule { get; set; }     
        public string Status { get; set; }            
    }

}

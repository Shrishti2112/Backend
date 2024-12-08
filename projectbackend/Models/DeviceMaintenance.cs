namespace SmartHomeAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DeviceMaintenance
    {
        [Key]
        public int MaintenanceId { get; set; }

        [Required]
        public int DeviceId { get; set; }  

     
        public Device Device { get; set; }  

        [Required]
        [MaxLength(100)]
        public string MaintenanceType { get; set; }  

        [Required]
        public DateTime LastServiceDate { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }  
    }

}

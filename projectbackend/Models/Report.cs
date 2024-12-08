namespace SmartHomeAPI.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }  

        [Required]
        public DateTime GeneratedDate { get; set; }

        [Required]
        public string Data { get; set; } 

        [Required]
        public string CreatedBy { get; set; }  
    }
}

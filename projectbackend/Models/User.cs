﻿namespace SmartHomeAPI.Models
{

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }

}

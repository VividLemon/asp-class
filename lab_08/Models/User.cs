using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace Lab_06.Models
{
    public class User : IdentityUser, IBaseModel
    {
        public int UserId { get; set; }
        public List<Video> Videos { get; set; }
        public List<Order> Orders { get; set; }
        public List<LikedVideo> LikedVideos {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

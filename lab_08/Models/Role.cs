using Microsoft.AspNetCore.Identity;
using System;
namespace Lab_06.Models
{
    public class Role : IdentityRole, IBaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

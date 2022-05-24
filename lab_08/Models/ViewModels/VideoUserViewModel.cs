using System.Collections.Generic;
using Lab_06.Models;
namespace Lab_06.Models.ViewModels
{
    public class VideoUserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public Video Video { get; set; }
    }
}

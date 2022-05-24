using System.Collections.Generic;
namespace Lab_06.Models
{
    public class User : BaseModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Video> Videos { get; set; }
    }
}

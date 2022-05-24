using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Lab_06.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> CartLines { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Line1 { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your zip")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
        public User User { get; set; }
    }
}

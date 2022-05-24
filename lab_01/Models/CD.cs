using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_02.Models
{
    public class CD
    {
        private const double COMPOUND_FREQUENCY = 365;
        [Required(ErrorMessage = "Please enter a bank")]
        public string Bank { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Value must be greater than {1}" )]
        public int TermsInMonths { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Value must be greater than {1}")]
        public double RateInPercent { get; set; }
        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.DateTime, ErrorMessage = "Must be a date")]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.DateTime, ErrorMessage = "Must be a date")]
        public float DepositAmount { get; set; }
        public virtual DateTime MaturityDate()
        {
            return PurchaseDate.AddMonths(TermsInMonths);
        }
        public virtual double ValueAtMaturity()
        {
            return DepositAmount * Math.Pow((1 + ((RateInPercent / 100)  / COMPOUND_FREQUENCY)), COMPOUND_FREQUENCY * (TermsInMonths / 12));
        }
    }
}

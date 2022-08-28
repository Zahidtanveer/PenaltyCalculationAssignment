using System;
using System.ComponentModel.DataAnnotations;
using Veripark.Assigment.Data.Models;

namespace Veripark.Assigment.Data.ViewModels
{
    public class PenaltyCalculationViewModel
    {
        [Required(ErrorMessage = "Please enter book checkout date")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "Please enter book return date")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        
        [Required(ErrorMessage = "Please select country")]
        public Country Country { get; set; }
    }
}

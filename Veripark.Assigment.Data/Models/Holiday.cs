using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veripark.Assigment.Data.Models
{
    [Table("Holidays")]
    public class Holiday
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}

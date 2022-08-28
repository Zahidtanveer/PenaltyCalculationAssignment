using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veripark.Assigment.Data.Models
{
    [Table("Countries")]
    public  class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
       
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}

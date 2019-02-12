using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QualityAssurance.Models
{
    public class Division
    {
        [Key]
        public int Divid { get; set; }
        public string DivName { get; set; }
        public Department Department { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QualityAssurance.Models
{
    public class Department
    {
        [Key]
        public int Deptid { get; set; }
        public string DeptName { get; set; }
        public ICollection<Division> Division { get; set; }
    }
}

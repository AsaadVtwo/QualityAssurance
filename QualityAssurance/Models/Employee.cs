using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QualityAssurance.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string EName { get; set; }
        //public string Job { get; set; }
        //public string Academic { get; set; }
        //public string Special { get; set; } //الاختصاص
        //public string Graduate { get; set; } //الجهة المانحة
        //public DateTime? DateOfHiring { get; set; } 
        //public DateTime? DateOfRehiring { get; set; } //تاريخ اعادة التعيين
        
        public Division Division { get; set; }
    }
}


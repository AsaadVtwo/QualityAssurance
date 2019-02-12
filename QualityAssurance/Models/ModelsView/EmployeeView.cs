using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityAssurance.Models.ModelsView
{
    public class EmployeeView
    {
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Department> Department { get; set; }
        public IEnumerable<Division> Division { get; set; }
        
    }
}

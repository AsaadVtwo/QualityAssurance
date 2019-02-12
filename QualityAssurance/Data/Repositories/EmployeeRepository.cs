

using Microsoft.EntityFrameworkCore;
using QualityAssurance.Data.Repositories.Interfaces;
using QualityAssurance.Models;
using QualityAssurance.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualityAssurance.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        { }
      
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}



using Microsoft.EntityFrameworkCore;
using QualityAssurance.Data.Repositories.Interfaces;
using QualityAssurance.Models;
using QualityAssurance.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualityAssurance.Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        { }
      
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}

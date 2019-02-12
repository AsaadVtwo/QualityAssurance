// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System.Threading.Tasks;
using QualityAssurance.Data.Repositories;
using QualityAssurance.Data.Repositories.Interfaces;


namespace QualityAssurance.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;


        IEmployeeRepository _employee;
        IDepartmentRepository _department;
        IDivisionRepository _division;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employee == null)
                    _employee = new EmployeeRepository(_context);

                return _employee;
            }
        }

        public IDepartmentRepository Department
        {
            get
            {
                if (_department == null)
                    _department = new DepartmentRepository(_context);

                return _department;
            }
        }

        public IDivisionRepository Division
        {
            get
            {
                if (_division == null)
                    _division = new DivisionRepository(_context);

                return _division;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}

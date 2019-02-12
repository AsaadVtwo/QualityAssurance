

using QualityAssurance.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace QualityAssurance.Data
{
    public interface IUnitOfWork
    {

        IEmployeeRepository Employees { get; }
        IDepartmentRepository Department { get; }
        IDivisionRepository Division { get; }

        Task<int> SaveChangesAsync();
    }
}

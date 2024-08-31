using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> AscendingOrder();
        Task<IEnumerable<Department>> DescndingOrder();

    }
}

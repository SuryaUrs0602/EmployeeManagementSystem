using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;

namespace EmployeeManagementSystem.Services.Contracts
{
    public interface IDepartmentService : IGenericRepository<Department>
    {
        Task<IEnumerable<GetDepartmentDTO>> DepartmentInAscendingOrder();

        Task<IEnumerable<GetDepartmentDTO>> DepartmentInDescendingOrder();
    }
}

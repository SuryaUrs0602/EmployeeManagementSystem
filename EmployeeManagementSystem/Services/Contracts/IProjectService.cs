using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;

namespace EmployeeManagementSystem.Services.Contracts
{
    public interface IProjectService : IGenericRepository<Project>
    {
        Task<IEnumerable<GetProjectDTO>> SortByAscending();
        Task<IEnumerable<GetProjectDTO>> SortByDescending();
    }
}

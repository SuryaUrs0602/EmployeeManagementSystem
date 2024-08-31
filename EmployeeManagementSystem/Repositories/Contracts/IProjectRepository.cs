using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IEnumerable<Project>> SortByAscending();
        Task<IEnumerable<Project>> SortByDescending();
    }
}

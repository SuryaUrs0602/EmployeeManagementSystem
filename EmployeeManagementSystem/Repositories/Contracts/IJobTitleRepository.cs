using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IJobTitleRepository : IGenericRepository<JobTitle>
    {
        Task<IEnumerable<JobTitle>> SortJobByAscending();
        Task<IEnumerable<JobTitle>> SortJobByDescending();
    }
}

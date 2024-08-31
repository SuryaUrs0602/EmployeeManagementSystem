using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;

namespace EmployeeManagementSystem.Services.Contracts
{
    public interface IJobTitleService : IGenericRepository<JobTitle>
    {
        Task<IEnumerable<GetJobTitleDTO>> SortByAscending();
        Task<IEnumerable<GetJobTitleDTO>> SortByDescending();
    }
}

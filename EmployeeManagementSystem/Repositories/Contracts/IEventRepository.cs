using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> SortByAscending();
        Task<IEnumerable<Event>> SortByDescending();
        Task<IEnumerable<Event>> GetByStatus(string status);



        Task<IEnumerable<Event>> GetAlltaskByProjectID(int projectID);
    }
}

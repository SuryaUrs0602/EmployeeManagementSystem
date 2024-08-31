using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;

namespace EmployeeManagementSystem.Services.Contracts
{
    public interface IEventService : IGenericRepository<Event>
    {
        Task<IEnumerable<GetEventDTO>> SortEventAscending();
        Task<IEnumerable<GetEventDTO>> SortEventDescending();
        Task<IEnumerable<GetEventDTO>> GetEventStatus(string status);



        Task<IEnumerable<GetEventByProjectDTO>> GetTasksOfaProject(int projectID);
    }
}

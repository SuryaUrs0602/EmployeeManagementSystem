using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetEmployeeByName(string name);
        Task<IEnumerable<Employee>> SortEmployeeByAscending();
        Task<IEnumerable<Employee>> SortEmployeeByDescending();



        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departemntID);
        Task<IEnumerable<Employee>> GetEmployeesByJobTitle(int jobTitleID);
        Task<IEnumerable<Employee>> GetEmployeesByProject(int projectID);
    }
}

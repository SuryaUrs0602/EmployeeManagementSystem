using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;

namespace EmployeeManagementSystem.Services.Contracts
{
    public interface IEmployeeService : IGenericRepository<Employee>
    {
        Task<GetEmployeeDTO> GetEmployeeByName(string name);
        Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByAscending();
        Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByDescending();



        Task<IEnumerable<GetEmployeeByDepartmentDTO>> GetAllEmployeesOfDepartemnt(int departmentID);
        Task<IEnumerable<GetEmployeeByJobTitleDTO>> GetAllEmployeesOfJobTitle(int jobTitleID);
        Task<IEnumerable<GetEmployeeByProjectDTO>> GetAllEmployeesOfProject(int projectID);
    }
}

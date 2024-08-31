using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Add(Employee obj)
        {
            try
            {
                _logger.LogInformation("Attempting to create Employee");
                await _employeeRepository.Add(obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while creating employee");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while creating employee");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while creating employee");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Delete(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to Delete Employee");
                await _employeeRepository.Delete(ID);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while deleting employee");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while deleting employee");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting employee");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all Employee data");
                return await _employeeRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEmployeeByDepartmentDTO>> GetAllEmployeesOfDepartemnt(int departmentID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all employee data by department ID");
                var data = await _employeeRepository.GetEmployeesByDepartment(departmentID);
                return data.Select(x => new GetEmployeeByDepartmentDTO
                {
                    EmployeeID = x.EmployeeID,
                    EmployeeName = x.EmployeeName,
                    EmployeeEmail = x.EmployeeEmail,
                    EmployeePhoneNumber = x.EmployeePhoneNumber,
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.Department.DepartmentName
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by department ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by department ID");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by department ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEmployeeByJobTitleDTO>> GetAllEmployeesOfJobTitle(int jobTitleID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all employee data by Jobtitle ID");
                var data =  await _employeeRepository.GetEmployeesByJobTitle(jobTitleID);
                return data.Select(emp => new GetEmployeeByJobTitleDTO
                {
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = emp.EmployeeName,
                    EmployeeEmail = emp.EmployeeEmail,
                    EmployeePhoneNumber = emp.EmployeePhoneNumber,
                    JobTitleID = emp.JobTitleID,
                    JobName = emp.JobTitle.JobName,
                    JobSalary = emp.JobTitle.JobSalary
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by jobtitle ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by jobtitle ID");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by jobtitle ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEmployeeByProjectDTO>> GetAllEmployeesOfProject(int projectID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all employee data by project ID");
                var data = await _employeeRepository.GetEmployeesByProject(projectID);
                return data.Select(emp => new GetEmployeeByProjectDTO
                {
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = emp.EmployeeName,
                    EmployeeEmail = emp.EmployeeEmail,
                    EmployeePhoneNumber = emp.EmployeePhoneNumber,
                    ProjectID = emp.ProjectID,
                    ProjectName = emp.Project.ProjectName,
                    ProjectDuration = emp.Project.ProjectDuration
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by project ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by project ID");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fecting all employee data by project ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<Employee> GetByID(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting Fetch employee ID");
                return await _employeeRepository.GetByID(ID);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee by ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee by ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<GetEmployeeDTO> GetEmployeeByName(string name)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch employee data by name");
                var data = await _employeeRepository.GetEmployeeByName(name);

                var dto = new GetEmployeeDTO
                {
                    EmployeeID = data.EmployeeID,
                    EmployeeName = data.EmployeeName,
                    EmployeeEmail = data.EmployeeEmail,
                    EmployeePhoneNumber = data.EmployeePhoneNumber,
                    ProjectID = data.ProjectID,
                    JobTitleID = data.JobTitleID,
                    DepartmentID = data.DepartmentID
                };
                return dto;
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee by name");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee by name");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee by name");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByAscending()
        {
            try
            {
                _logger.LogInformation("Attempting to Fetch all employee data in ascending order");
                var data = await _employeeRepository.SortEmployeeByAscending();
                
                    return data.Select(emp => new GetEmployeeDTO
                    {
                        EmployeeID = emp.EmployeeID,
                        EmployeeName = emp.EmployeeName,
                        EmployeeEmail = emp.EmployeeEmail,
                        EmployeePhoneNumber = emp.EmployeePhoneNumber,
                        ProjectID = emp.ProjectID, 
                        JobTitleID = emp.JobTitleID,
                        DepartmentID = emp.DepartmentID
                    });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in ascending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in ascending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in ascending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByDescending()
        {
            try
            {
                _logger.LogInformation("Attemping to fetch all employee data in descending order");
                var data = await _employeeRepository.SortEmployeeByDescending();
                return data.Select(emp => new GetEmployeeDTO
                {
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = emp.EmployeeName,
                    EmployeeEmail = emp.EmployeeEmail,
                    EmployeePhoneNumber = emp.EmployeePhoneNumber,
                    ProjectID = emp.ProjectID,
                    JobTitleID = emp.JobTitleID,
                    DepartmentID = emp.DepartmentID
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in descending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in descending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching employee data in descending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Update(object ID, Employee obj)
        {
            try
            {
                _logger.LogInformation("Attempting to update employee data");
                await _employeeRepository.Update(ID, obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while updating employee");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while updating employee");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating employee");
                throw new Exception("Could not process due to some error");
            }
        }
    }
}

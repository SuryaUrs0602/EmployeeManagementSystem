using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        //{
        //    var emp = new Employee
        //    {
        //        EmployeeName = employeeDTO.EmployeeName,
        //        EmployeeEmail = employeeDTO.EmployeeEmail,
        //        EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
        //        DepartmentID = employeeDTO.DepartmentID,
        //        JobTitleID = employeeDTO.JobTitleID,
        //        ProjectID = employeeDTO.ProjectID,
        //    };

        //    await _employeeService.Add(emp);
        //    return Created();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllEmployees()
        //{
        //    var data = await _employeeService.GetAll();
        //    return Ok(data);
        //}

        //[HttpGet("EmployeeID")]
        //public async Task<IActionResult> GetEmployeeByID(int EmployeeID)
        //{
        //    var data = await _employeeService.GetByID(EmployeeID);
        //    return Ok(data);
        //}

        //[HttpDelete("EmployeeID")]
        //public async Task<IActionResult> DeleteEmployee(int EmployeeID)
        //{
        //    await _employeeService.Delete(EmployeeID);
        //    return NoContent();
        //}

        //[HttpPut("EmployeeID")]
        //public async Task<IActionResult> EditEmployeeDetails(int EmployeeID, EmployeeDTO employeeDTO)
        //{
        //    var emp = new Employee
        //    {
        //        EmployeeName = employeeDTO.EmployeeName,
        //        EmployeeEmail = employeeDTO.EmployeeEmail,
        //        EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
        //        DepartmentID = employeeDTO.DepartmentID,
        //        JobTitleID = employeeDTO.JobTitleID,
        //        ProjectID = employeeDTO.ProjectID,
        //    };

        //    await _employeeService.Update(EmployeeID, emp);
        //    return NoContent();
        //}

        //[HttpGet("EmployeeName")]
        //public async Task<IActionResult> GetEmployeeByName(string EmployeeName)
        //{
        //    var data = await _employeeService.GetEmployeeByName(EmployeeName);
        //    return Ok(data);
        //}

        //[HttpGet("sortasc")]
        //public async Task<IActionResult> SortEmployeeByAscending()
        //{
        //    var data = await _employeeService.SortEmployeeByAscending();
        //    return Ok(data);
        //}

        //[HttpGet("sortdesc")]
        //public async Task<IActionResult> SortEmployeeByDescending()
        //{
        //    var data = await _employeeService.SortEmployeeByDescending();
        //    return Ok(data);
        //}

        //[HttpGet("bydepartmentID")]
        //public async Task<IActionResult> GetAllEmployeeDepartment(int departmentID)
        //{
        //    var data = await _employeeService.GetAllEmployeesOfDepartemnt(departmentID);
        //    return Ok(data);
        //}

        //[HttpGet("byprojectID")]
        //public async Task<IActionResult> GetAllEmployeeProject(int projectID)
        //{
        //    var data = await _employeeService.GetAllEmployeesOfProject(projectID);
        //    return Ok(data);
        //}

        //[HttpGet("byjobtitleID")]
        //public async Task<IActionResult> GetAllEmployeeJobTitle(int jobTitleID)
        //{
        //    var data = await _employeeService.GetAllEmployeesOfJobTitle(jobTitleID);
        //    return Ok(data);
        //}





        [HttpPost]
        public async Task AddEmployee(EmployeeDTO employeeDTO)
        {
            var emp = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                EmployeeEmail = employeeDTO.EmployeeEmail,
                EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                DepartmentID = employeeDTO.DepartmentID,
                JobTitleID = employeeDTO.JobTitleID,
                ProjectID = employeeDTO.ProjectID,
            };

            _logger.LogInformation("Creating a new Employee");
            await _employeeService.Add(emp);
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            _logger.LogInformation("Fetching all Employees data");
            return await _employeeService.GetAll();
        }

        [HttpGet("EmployeeID")]
        public async Task<Employee> GetEmployeeByID(int EmployeeID)
        {
            _logger.LogInformation("Fetching employee data by ID");
            return await _employeeService.GetByID(EmployeeID);
        }

        [HttpDelete("EmployeeID")]
        public async Task DeleteEmployee(int EmployeeID)
        {
            _logger.LogInformation("Deleting the employee");
            await _employeeService.Delete(EmployeeID);
        }

        [HttpPut("EmployeeID")]
        public async Task EditEmployeeDetails(int EmployeeID, EmployeeDTO employeeDTO)
        {
            var emp = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                EmployeeEmail = employeeDTO.EmployeeEmail,
                EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                DepartmentID = employeeDTO.DepartmentID,
                JobTitleID = employeeDTO.JobTitleID,
                ProjectID = employeeDTO.ProjectID,
            };

            _logger.LogInformation("Updating the Employee Data");
            await _employeeService.Update(EmployeeID, emp);
        }

        [HttpGet("EmployeeName")]
        public async Task<GetEmployeeDTO> GetEmployeeByName(string EmployeeName)
        {
            _logger.LogInformation("Fetching Employee Data by Name");
            return await _employeeService.GetEmployeeByName(EmployeeName);
        }

        [HttpGet("SortAsc")]
        public async Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByAscending()
        {
            _logger.LogInformation("Fetching all Employee data in ascending order");
            return await _employeeService.SortEmployeeByAscending();
        }

        [HttpGet("SortDesc")]
        public async Task<IEnumerable<GetEmployeeDTO>> SortEmployeeByDescending()
        {
            _logger.LogInformation("Fetching all Employee data in descending order");
            return await _employeeService.SortEmployeeByDescending();
        }

        [HttpGet("DepartmentID")]
        public async Task<IEnumerable<GetEmployeeByDepartmentDTO>> GetAllEmployeeDepartment(int departmentID)
        {
            _logger.LogInformation("Fetching all employee data by Department ID");
            return await _employeeService.GetAllEmployeesOfDepartemnt(departmentID);
        }

        [HttpGet("ProjectID")]
        public async Task<IEnumerable<GetEmployeeByProjectDTO>> GetAllEmployeeProject(int projectID)
        {
            _logger.LogInformation("Fetching all employee data by project ID");
            return await _employeeService.GetAllEmployeesOfProject(projectID);
        }

        [HttpGet("JobtitleID")]
        public async Task<IEnumerable<GetEmployeeByJobTitleDTO>> GetAllEmployeeJobTitle(int jobTitleID)
        {
            _logger.LogInformation("Fetching all employee data by JObTitle ID");
            return await _employeeService.GetAllEmployeesOfJobTitle(jobTitleID);
        }
    }
}

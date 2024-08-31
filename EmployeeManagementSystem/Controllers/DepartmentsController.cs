using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Transactions;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentsService;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(IDepartmentService departmentService, ILogger<DepartmentsController> logger)
        {
            _departmentsService = departmentService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddDepartment(DepartmentDTO departmentDTO)
        //{
        //    var department = new Department
        //    {
        //        DepartmentName = departmentDTO.DepartmentName
        //    };

        //    await _departmentsService.Add(department);
        //    return Created();
        //}

        //[HttpDelete("DepartmentID")]
        //public async Task<IActionResult> DeleteDepartment(int DepartmentID)
        //{
        //    await _departmentsService.Delete(DepartmentID);
        //    return NoContent();
        //}

        //[HttpGet("sortasc")]
        //public async Task<IActionResult> SortDepartmentByAscending()
        //{
        //    var data = await _departmentsService.DepartmentInAscendingOrder();
        //    return Ok(data);
        //}

        //[HttpGet("sortdesc")]
        //public async Task<IActionResult> SortDepartmentByDescending()
        //{
        //    var data = await _departmentsService.DepartmentInDescendingOrder();
        //    return Ok(data);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllDepartments()
        //{
        //    var data = await _departmentsService.GetAll();
        //    return Ok(data);
        //}

        //[HttpGet("DepartmentID")]
        //public async Task<IActionResult> GetDepartmentByID(int DepartmentID)
        //{
        //    var data = await _departmentsService.GetByID(DepartmentID);
        //    return Ok(data);
        //}

        //[HttpPut("DepartmentID")]
        //public async Task<IActionResult> EditDepartmentData(int DepartmentID, DepartmentDTO departmentDTO)
        //{
        //    var department = new Department
        //    {
        //        DepartmentName = departmentDTO.DepartmentName
        //    };

        //    await _departmentsService.Update(DepartmentID, department);
        //    return NoContent();
        //}

        [HttpPost]
        public async Task AddDepartment(DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                DepartmentName = departmentDTO.Name
            };

            _logger.LogInformation("Creating a new Department");
            await _departmentsService.Add(department);
        }

        [HttpDelete("DepartmentID")]
        public async Task DeleteDepartment(int DepartmentID)
        {
            _logger.LogInformation("Deleting the Department");
            await _departmentsService.Delete(DepartmentID);
        }

        [HttpGet("SortAsc")]
        public async Task<IEnumerable<GetDepartmentDTO>> SortDepartmentByAscending()
        {
            _logger.LogInformation("Fetching all sorted Item");
            return await _departmentsService.DepartmentInAscendingOrder();
        }

        [HttpGet("SortDesc")]
        public async Task<IEnumerable<GetDepartmentDTO>> SortDepartmentByDescending()
        {
            _logger.LogInformation("Fetching all descending Order sorted Item");
            return await _departmentsService.DepartmentInDescendingOrder();
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            _logger.LogInformation("Fetching all Departments data");
            return await _departmentsService.GetAll();
        }

        [HttpGet("DepartmentID")]
        public async Task<Department> GetDepartmentByID(int DepartmentID)
        {
            _logger.LogInformation("Fetching Department data by ID");
            return await _departmentsService.GetByID(DepartmentID);
        }

        [HttpPut("DepartmentID")]
        public async Task EditDepartmentData(int DepartmentID, DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                DepartmentName = departmentDTO.Name
            };

            _logger.LogInformation("Updating the Department data");
            await _departmentsService.Update(DepartmentID, department);
        }
    }
}

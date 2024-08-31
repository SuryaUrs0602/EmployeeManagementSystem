using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {

        private readonly EmployeeManagementDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeManagementDbContext context, ILogger<EmployeeRepository> logger)
            : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            _logger.LogInformation("Fetched employee data by name");
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeName == name);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departemntID)
        {
            _logger.LogInformation("Fetched employee data by department ID");
            return await _context.Employees
                .Where(emp => emp.DepartmentID == departemntID)
                .Include(emp => emp.Department)
                .ToListAsync();


            //return await _context.Employees
            //    .Where(emp => emp.DepartmentID == departemntID)
            //    .Select(emp => new GetEmployeeByDepartmentDTO
            //    {
            //        EmployeeID = emp.EmployeeID,
            //        EmployeeName = emp.EmployeeName,
            //        EmployeeEmail = emp.EmployeeEmail,
            //        EmployeePhoneNumber = emp.EmployeePhoneNumber,
            //        DepartmentID = emp.DepartmentID,
            //        DepartmentName = emp.Department.DepartmentName
            //    }).ToListAsync();


        }

        public async Task<IEnumerable<Employee>> GetEmployeesByJobTitle(int jobTitleID)
        {
            _logger.LogInformation("Fetched all employee data by jobtitle ID");
            return await _context.Employees
                .Where(emp => emp.JobTitleID == jobTitleID)
                .Include(emp => emp.JobTitle)
                .ToListAsync();


            //return await _context.Employees
            //    .Where(emp => emp.JobTitleID == jobTitleID)
            //    .Select(emp => new GetEmployeeByJobTitleDTO
            //    {
            //        EmployeeID = emp.EmployeeID,
            //        EmployeeName = emp.EmployeeName,
            //        EmployeeEmail = emp.EmployeeEmail,
            //        EmployeePhoneNumber = emp.EmployeePhoneNumber,
            //        JobTitleID = emp.JobTitleID,
            //        JobName = emp.JobTitle.JobName,
            //        JobSalary = emp.JobTitle.JobSalary
            //    }).ToListAsync();


        }

        public async Task<IEnumerable<Employee>> GetEmployeesByProject(int projectID)
        {
            _logger.LogInformation("Fetched employee data by project ID");
            return await _context.Employees
                .Where(emp => emp.ProjectID == projectID)
                .Include(emp => emp.Project)
                .ToListAsync();


            //return await _context.Employees
            //    .Where(emp => emp.ProjectID == projectID)
            //    .Select(emp => new GetEmployeeByProjectDTO
            //    {
            //        EmployeeID = emp.EmployeeID,
            //        EmployeeName = emp.EmployeeName,
            //        EmployeeEmail = emp.EmployeeEmail,
            //        EmployeePhoneNumber = emp.EmployeePhoneNumber,
            //        ProjectID = emp.Project.ProjectID,
            //        ProjectName = emp.Project.ProjectName,
            //        ProjectDuration = emp.Project.ProjectDuration
            //    }).ToListAsync();


            
        }

        public async Task<IEnumerable<Employee>> SortEmployeeByAscending()
        {
            _logger.LogInformation("Fetched employee data in ascending order");
            return await _context.Employees
                .OrderBy(emp => emp.EmployeeName)
                .ToListAsync();

            //return await _context.Employees
            //    .OrderBy(emp => emp.EmployeeName)
            //    .Select(emp => new GetEmployeeDTO
            //    {
            //        EmployeeID = emp.EmployeeID,
            //        EmployeeName = emp.EmployeeName,
            //        EmployeeEmail = emp.EmployeeEmail,
            //        EmployeePhoneNumber = emp.EmployeePhoneNumber,
            //        ProjectID = emp.ProjectID,
            //        JobTitleID = emp.JobTitleID,
            //        DepartmentID = emp.DepartmentID
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SortEmployeeByDescending()
        {
            _logger.LogInformation("Fetched employee data by descending order");
            return await _context.Employees
                .OrderByDescending(emp => emp.EmployeeName)
                .ToListAsync();

            //return await _context.Employees
            //    .OrderByDescending(emp => emp.EmployeeName)
            //    .Select(emp => new GetEmployeeDTO
            //    {
            //        EmployeeID = emp.EmployeeID,
            //        EmployeeName = emp.EmployeeName,
            //        EmployeeEmail = emp.EmployeeEmail,
            //        EmployeePhoneNumber = emp.EmployeePhoneNumber,
            //        ProjectID = emp.ProjectID,
            //        JobTitleID = emp.JobTitleID,
            //        DepartmentID = emp.DepartmentID
            //    })
            //    .ToListAsync();
        }
    }
}

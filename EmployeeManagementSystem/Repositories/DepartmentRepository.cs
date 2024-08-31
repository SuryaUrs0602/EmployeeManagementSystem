using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace EmployeeManagementSystem.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        private readonly EmployeeManagementDbContext _context;
        private readonly ILogger<DepartmentRepository> _logger;

        public DepartmentRepository(EmployeeManagementDbContext context, ILogger<DepartmentRepository> logger) 
            : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Department>> AscendingOrder()
        {

            _logger.LogInformation("Fetched all Department data in ascending order");
            return await _context.Departments
                .OrderBy(department => department.DepartmentName)
                .ToListAsync();

            //return await _context.Departments
            //    .OrderBy(dept => dept.DepartmentName)
            //    .Select(dept => new GetDepartmentDTO
            //    {
            //        DepartmentID = dept.DepartmentID,
            //        DepartmentName = dept.DepartmentName
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Department>> DescndingOrder()
        {
            _logger.LogInformation("Fetched all Department data in descending order");
            return await _context.Departments
                .OrderByDescending(department => department.DepartmentName)
                .ToListAsync();

            //return await _context.Departments
            //    .OrderByDescending(dept => dept.DepartmentName)
            //    .Select(dept => new GetDepartmentDTO
            //    {
            //        DepartmentID = dept.DepartmentID,
            //        DepartmentName = dept.DepartmentName
            //    })
            //    .ToListAsync();
        }
    }
}

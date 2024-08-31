using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace EmployeeManagementSystem.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {

        private readonly EmployeeManagementDbContext _context;
        private readonly ILogger<ProjectRepository> _logger;

        public ProjectRepository(EmployeeManagementDbContext context, ILogger<ProjectRepository> logger) 
            : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Project>> SortByAscending()
        {
            _logger.LogInformation("Fetched all data of projects in ascending order");
            return await _context.Projects
                .OrderBy(project => project.ProjectName)
                .ToListAsync();

            //return await _context.Projects
            //    .OrderBy(pro => pro.ProjectName)
            //    .Select(pro => new GetProjectDTO
            //    {
            //        ProjectID = pro.ProjectID,
            //        ProjectName = pro.ProjectName,
            //        ProjectDuration = pro.ProjectDuration
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Project>> SortByDescending()
        {
            _logger.LogInformation("Fetched all data of projects in descending order");
            return await _context.Projects
                .OrderByDescending(project => project.ProjectName)
                .ToListAsync();

            //return await _context.Projects
            //    .OrderByDescending(pro => pro.ProjectName)
            //    .Select(pro => new GetProjectDTO
            //    {
            //        ProjectID = pro.ProjectID,
            //        ProjectName = pro.ProjectName,
            //        ProjectDuration = pro.ProjectDuration
            //    })
            //    .ToListAsync();
        }


    }
}

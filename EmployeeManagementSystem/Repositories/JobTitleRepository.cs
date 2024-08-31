using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class JobTitleRepository : GenericRepository<JobTitle>, IJobTitleRepository
    {

        private readonly EmployeeManagementDbContext _context;
        private readonly ILogger<JobTitleRepository> _logger;

        public JobTitleRepository(EmployeeManagementDbContext context, ILogger<JobTitleRepository> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<JobTitle>> SortJobByAscending()
        {
            _logger.LogInformation("Fetched all jobtitles in ascending order");
            return await _context.JobTitles
                .OrderBy(job => job.JobName)
                .ToListAsync();

            //return await _context.JobTitles
            //    .OrderBy(job => job.JobName)
            //    .Select(job => new GetJobTitleDTO
            //    {
            //        JobTitleID = job.JobTitleID,
            //        JobName = job.JobName,
            //        JobSalary = job.JobSalary
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<JobTitle>> SortJobByDescending()
        {
            _logger.LogInformation("Fetched all events in descending order");
            return await _context.JobTitles
                .OrderByDescending(job => job.JobName)
                .ToListAsync();

            //return await _context.JobTitles
            //    .OrderByDescending(job => job.JobName)
            //    .Select(job => new GetJobTitleDTO
            //    {
            //        JobTitleID = job.JobTitleID,
            //        JobName = job.JobName,
            //        JobSalary = job.JobSalary
            //    })
            //    .ToListAsync();
        }
    }
}

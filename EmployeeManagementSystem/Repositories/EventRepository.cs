using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly EmployeeManagementDbContext _context;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(EmployeeManagementDbContext context, ILogger<EventRepository> logger)
            : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Event>> GetAlltaskByProjectID(int projectID)
        {
            _logger.LogInformation("Fetched all tasks by project ID");
            return await _context.Tasks
                .Where(x => x.ProjectID == projectID)
                .Include(x => x.Project)
                .ToListAsync();

            //return await _context.Tasks
            //    .Where(task => task.ProjectID == projectID)
            //    .Select(task => new GetEventByProjectDTO
            //    {
            //        TaskID = task.TaskID,
            //        TaskName = task.TaskName,
            //        TaskStatus = task.TaskStatus,
            //        ProjectID = task.Project.ProjectID,
            //        ProjectName = task.Project.ProjectName,
            //        ProjectDuration = task.Project.ProjectDuration
            //    }).ToListAsync();

        }

        public async Task<IEnumerable<Event>> GetByStatus(string status)
        {
            _logger.LogInformation("Fetched all tasks by status");
            return await _context.Tasks
                .Where(x => x.TaskStatus == status)
                .ToListAsync();

            //return await _context.Tasks
            //    .Where(x => x.TaskStatus == status)
            //    .Select(task => new GetEventDTO
            //    {
            //        TaskID = task.TaskID,
            //        TaskName = task.TaskName,
            //        TaskStatus = task.TaskStatus
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Event>> SortByAscending()
        {
            _logger.LogInformation("Fetched all events in ascending order");
            return await _context.Tasks
                .OrderBy(x => x.TaskName)
                .ToListAsync();

            //return await _context.Tasks
            //    .OrderBy(task => task.TaskName)
            //    .Select(task => new GetEventDTO
            //    {
            //        TaskID = task.TaskID,
            //        TaskName = task.TaskName,
            //        TaskStatus = task.TaskStatus
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Event>> SortByDescending()
        {
            _logger.LogInformation("Fetched all events in descending order");
            return await _context.Tasks
                .OrderByDescending(x => x.TaskName)
                .ToListAsync();

            //return await _context.Tasks
            //    .OrderByDescending(task => task.TaskName)
            //    .Select(task => new GetEventDTO
            //    {
            //        TaskID = task.TaskID,
            //        TaskName = task.TaskName,
            //        TaskStatus = task.TaskStatus
            //    })
            //    .ToListAsync();
        }
    }
}

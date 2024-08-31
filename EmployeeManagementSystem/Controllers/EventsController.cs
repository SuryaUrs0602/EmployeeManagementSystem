using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.InteropServices;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _eventService;
        private readonly ILogger<EventsController> _logger;
        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddEvent(EventDTO eventDTO)
        //{
        //    var eve = new Event
        //    {
        //        TaskName = eventDTO.TaskName,
        //        TaskStatus = eventDTO.TaskStatus,
        //        ProjectID = eventDTO.ProjectID
        //    };

        //    await _eventService.Add(eve);
        //    return Created();
        //}

        //[HttpDelete("TaskID")]
        //public async Task<IActionResult> DeleteEvent(int TaskID)
        //{
        //    await _eventService.Delete(TaskID);
        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllEvent()
        //{
        //    var data = await _eventService.GetAll();
        //    return Ok(data);
        //}

        //[HttpGet("TaskID")]
        //public async Task<IActionResult> GetEventByID(int TaskID)
        //{
        //    var data = await _eventService.GetByID(TaskID);
        //    return Ok(data);
        //}

        //[HttpGet("sortasc")]
        //public async Task<IActionResult> SortEventByAscending()
        //{
        //    var data = await _eventService.SortEventAscending();
        //    return Ok(data);
        //}

        //[HttpGet("sortdesc")]
        //public async Task<IActionResult> SortEventByDescending()
        //{
        //    var data = await _eventService.SortEventDescending();
        //    return Ok(data);
        //}

        //[HttpPut("TaskID")]
        //public async Task<IActionResult> EditEvent(int TaskID, EventDTO eventDTO)
        //{
        //    var eve = new Event
        //    {
        //        TaskName = eventDTO.TaskName,
        //        TaskStatus = eventDTO.TaskStatus,
        //        ProjectID = eventDTO.ProjectID
        //    };

        //    await _eventService.Update(TaskID, eve);
        //    return NoContent();
        //}

        //[HttpGet("status")]
        //public async Task<IActionResult> GetEventByEventStatus(string status)
        //{
        //    var data = await _eventService.GetEventStatus(status);
        //    return Ok(data);
        //}

        //[HttpGet("byprojectID")]
        //public async Task<IActionResult> GetAllEventOfProject(int projectID)
        //{
        //    var data = await _eventService.GetTasksOfaProject(projectID);
        //    return Ok(data);
        //}

        [HttpPost]
        public async Task AddEvent(EventDTO eventDTO)
        {
            var eve = new Event
            {
                TaskName = eventDTO.TaskName,
                TaskStatus = eventDTO.TaskStatus,
                ProjectID = eventDTO.ProjectID
            };

            _logger.LogInformation("Creating new Event");
            await _eventService.Add(eve);
        }

        [HttpDelete("TaskID")]
        public async Task DeleteEvent(int TaskID)
        {
            _logger.LogInformation("Deleting the Event");
            await _eventService.Delete(TaskID);
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetAllEvent()
        {
            _logger.LogInformation("Fetching all Events data");
            return await _eventService.GetAll();
        }

        [HttpGet("TaskID")]
        public async Task<Event> GetEventByID(int TaskID)
        {
            _logger.LogInformation("Fetching Events by ID");
            return await _eventService.GetByID(TaskID);
        }

        [HttpGet("SortAsc")]
        public async Task<IEnumerable<GetEventDTO>> SortEventByAscending()
        {
            _logger.LogInformation("Fetching all Events data in ascending order");
            return await _eventService.SortEventAscending();
        }

        [HttpGet("SortDesc")]
        public async Task<IEnumerable<GetEventDTO>> SortEventByDescending()
        {
            _logger.LogInformation("Fetching all Events data in descending order");
            return await _eventService.SortEventDescending();
        }

        [HttpPut("TaskID")]
        public async Task EditEvent(int TaskID, EventDTO eventDTO)
        {
            var eve = new Event
            {
                TaskName = eventDTO.TaskName,
                TaskStatus = eventDTO.TaskStatus,
                ProjectID = eventDTO.ProjectID
            };

            _logger.LogInformation("Updating the Event data");
            await _eventService.Update(TaskID, eve);
        }

        [HttpGet("Status")]
        public async Task<IEnumerable<GetEventDTO>> GetEventByEventStatus(string status)
        {
            _logger.LogInformation("Fetching all Events by Event status");
            return await _eventService.GetEventStatus(status);
        }

        [HttpGet("ProjectID")]
        public async Task<IEnumerable<GetEventByProjectDTO>> GetAllEventOfProject(int projectID)
        {
            _logger.LogInformation("Fetching all Events by prject ID");
            return await _eventService.GetTasksOfaProject(projectID);
        }
    }
}

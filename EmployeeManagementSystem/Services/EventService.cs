using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EmployeeManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<EventService> _logger;

        public EventService(IEventRepository eventRepository, ILogger<EventService> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        public async Task Add(Event obj)
        {
            try
            {
                _logger.LogInformation("Attempting to create new Event");
                await _eventRepository.Add(obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while creating event");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while creating event");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while creating event");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Delete(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to delete Event data");
                await _eventRepository.Delete(ID);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while deleting event");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while deleting event");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting event");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all event data");
                return await _eventRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event data");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event datat");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching event data");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<Event> GetByID(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting fetch event data by ID");
                return await _eventRepository.GetByID(ID);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEventDTO>> GetEventStatus(string status)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch event by status");
                var data = await _eventRepository.GetByStatus(status);
                return data.Select(x => new GetEventDTO
                {
                    TaskID = x.TaskID,
                    TaskName = x.TaskName,
                    TaskStatus = x.TaskStatus
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by status");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by status");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by status");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEventByProjectDTO>> GetTasksOfaProject(int projectID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch event by projectID");
                var data = await _eventRepository.GetAlltaskByProjectID(projectID);
                return data.Select(x => new GetEventByProjectDTO
                {
                    TaskID = x.TaskID,
                    TaskName = x.TaskName,
                    TaskStatus = x.TaskStatus,
                    ProjectID = x.Project.ProjectID,
                    ProjectName = x.Project.ProjectName,
                    ProjectDuration = x.Project.ProjectDuration
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by projectID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by projectID");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching event by projectID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEventDTO>> SortEventAscending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch events in ascending order");
                var data = await _eventRepository.SortByAscending();
                return data.Select(x => new GetEventDTO
                {
                    TaskID = x.TaskID,
                    TaskName = x.TaskName,
                    TaskStatus = x.TaskStatus
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in ascending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in ascending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in ascending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetEventDTO>> SortEventDescending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch events in descending order");
                var data = await _eventRepository.SortByDescending();
                return data.Select(x => new GetEventDTO
                {
                    TaskID = x.TaskID,
                    TaskName = x.TaskName,
                    TaskStatus = x.TaskStatus
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in descending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in descending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching events in descending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Update(object ID, Event obj)
        {
            try
            {
                _logger.LogInformation("Attempting to update event");
                await _eventRepository.Update(ID, obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while updating event");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while updating event");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating event");
                throw new Exception("Could not process due to some error");
            }
        }
    }
}

using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class ProjectService : IProjectService
    {

        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task Add(Project obj)
        {
            try
            {
                _logger.LogInformation("Attempting to create project");
                await _projectRepository.Add(obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while creating project");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while creating project");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while creating project");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Delete(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to Delete project");
                await _projectRepository.Delete(ID);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while deleting project");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while deleting project");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting project");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all project");
                return await _projectRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all project");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all project");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all project");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<Project> GetByID(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch project by ID");
                return await _projectRepository.GetByID(ID);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project by ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project by ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetProjectDTO>> SortByAscending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch project in ascending order");
                var data = await _projectRepository.SortByAscending();
                return data.Select(project => new GetProjectDTO
                {
                    ProjectID = project.ProjectID,
                    ProjectName = project.ProjectName,
                    ProjectDuration = project.ProjectDuration
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in ascending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in ascending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in ascending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetProjectDTO>> SortByDescending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch project in descending order");
                var data = await _projectRepository.SortByDescending();
                return data.Select(project => new GetProjectDTO
                {
                    ProjectID = project.ProjectID,
                    ProjectName = project.ProjectName,
                    ProjectDuration = project.ProjectDuration
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in descending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in descending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng project in descending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Update(object ID, Project obj)
        {
            try
            {
                _logger.LogInformation("Attempting to update project");
                await _projectRepository.Update(ID, obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while updating project");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while updating project");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating project");
                throw new Exception("Could not process due to some error");
            }
        }
    }
}

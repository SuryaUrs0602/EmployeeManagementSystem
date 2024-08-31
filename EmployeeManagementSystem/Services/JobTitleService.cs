using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class JobTitleService : IJobTitleService
    {

        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly ILogger<JobTitleService> _logger;

        public JobTitleService(IJobTitleRepository jobTitleRepository, ILogger<JobTitleService> logger)
        {
            _jobTitleRepository = jobTitleRepository;
            _logger = logger;
        }

        public async Task Add(JobTitle obj)
        {
            try
            {
                _logger.LogInformation("Attempting to create jobtitle");
                await _jobTitleRepository.Add(obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while creating jobtitle");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while creating jobtitle");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while creating jobtitle");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Delete(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to Delete jobtitle");
                await _jobTitleRepository.Delete(ID);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while deleting jobtitle");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while deleting jobtitle");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting jobtitle");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<JobTitle>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all jobtitle");
                return await _jobTitleRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all jobtitle");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all jobtitle");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng all jobtitle");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<JobTitle> GetByID(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to fetch jobtitle by ID");
                return await _jobTitleRepository.GetByID(ID);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle by ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle by ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetJobTitleDTO>> SortByAscending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch jobtitle in ascending order");
                var data = await _jobTitleRepository.SortJobByAscending();
                return data.Select(job => new GetJobTitleDTO
                {
                    JobTitleID = job.JobTitleID,
                    JobName = job.JobName,
                    JobSalary = job.JobSalary
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in ascending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in ascending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in ascending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetJobTitleDTO>> SortByDescending()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch jobtitle in descending order");
                var data = await _jobTitleRepository.SortJobByDescending();
                return data.Select(job => new GetJobTitleDTO
                {
                    JobTitleID = job.JobTitleID,
                    JobName = job.JobName,
                    JobSalary = job.JobSalary
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in descending order");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in descending order");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetchng jobtitle in descending order");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Update(object ID, JobTitle obj)
        {
            try
            {
                _logger.LogInformation("Attempting to update Jobtitlr");
                await _jobTitleRepository.Update(ID, obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occured while updating jobtitle");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error occured while updating jobtitle");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating jobtitle");
                throw new Exception("Could not process due to some error");
            }
        }
    }
}

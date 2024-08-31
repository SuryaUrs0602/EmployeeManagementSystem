using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {

        private readonly IJobTitleService _jobTitleService;
        private readonly ILogger<JobTitlesController> _logger;

        public JobTitlesController(IJobTitleService jobTitleService, ILogger<JobTitlesController> logger)
        {
            _jobTitleService = jobTitleService;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddJobTitle(JobTitleDTO jobTitleDTO)
        //{
        //    var jobTitle = new JobTitle
        //    {
        //        JobName = jobTitleDTO.JobName,
        //        JobSalary = jobTitleDTO.JobSalary
        //    };

        //    await _jobTitleService.Add(jobTitle);
        //    return Created();
        //}

        //[HttpDelete("JobTitleID")]
        //public async Task<IActionResult> DeleteJobTitle(int JobTitleID)
        //{
        //    await _jobTitleService.Delete(JobTitleID);
        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllJobTitle()
        //{
        //    var data = await _jobTitleService.GetAll();
        //    return Ok(data);
        //}

        //[HttpGet("JobTitleID")]
        //public async Task<IActionResult> GetJobTitleByID(int JobTitleID)
        //{
        //    var data = await _jobTitleService.GetByID(JobTitleID);
        //    return Ok(data);
        //}

        //[HttpGet("sortasc")]
        //public async Task<IActionResult> SortJobTitleAscending()
        //{
        //    var data = await _jobTitleService.SortByAscending();
        //    return Ok(data);
        //}

        //[HttpGet("sortdesc")]
        //public async Task<IActionResult> SortJobTitleDescending()
        //{
        //    var data = await _jobTitleService.SortByDescending();
        //    return Ok(data);
        //}

        //[HttpPut("JobTitleID")]
        //public async Task<IActionResult> EditJobTitle(int JobTitleID, JobTitleDTO jobTitleDTO)
        //{
        //    var jobTitle = new JobTitle
        //    {
        //        JobName = jobTitleDTO.JobName,
        //        JobSalary = jobTitleDTO.JobSalary

        //    };

        //    await _jobTitleService.Update(JobTitleID, jobTitle);
        //    return NoContent();
        //}

        [HttpPost]
        public async Task AddJobTitle(JobTitleDTO jobTitleDTO)
        {
            var jobTitle = new JobTitle
            {
                JobName = jobTitleDTO.JobName,
                JobSalary = jobTitleDTO.JobSalary
            };

            _logger.LogInformation("Cretating a new JobTitle");
            await _jobTitleService.Add(jobTitle);
        }

        [HttpDelete("JobTitleID")]
        public async Task DeleteJobTitle(int JobTitleID)
        {
            _logger.LogInformation("Deleting the JObTitle Data");
            await _jobTitleService.Delete(JobTitleID);
        }

        [HttpGet]
        public async Task<IEnumerable<JobTitle>> GetAllJobTitle()
        {
            _logger.LogInformation("Fetching all JObTitle Data");
            return await _jobTitleService.GetAll();
        }

        [HttpGet("JobTitleID")]
        public async Task<JobTitle> GetJobTitleByID(int JobTitleID)
        {
            _logger.LogInformation("Fetching all JObTitle by ID");
            return await _jobTitleService.GetByID(JobTitleID);
        }

        [HttpGet("SortAsc")]
        public async Task<IEnumerable<GetJobTitleDTO>> SortJobTitleAscending()
        {
            _logger.LogInformation("Fetching all JObTitle in ascending Order");
            return await _jobTitleService.SortByAscending();
        }

        [HttpGet("SortDesc")]
        public async Task<IEnumerable<GetJobTitleDTO>> SortJobTitleDescending()
        {
            _logger.LogInformation("Fetching all JObTitle in descending order");
            return await _jobTitleService.SortByDescending();
        }

        [HttpPut("JobTitleID")]
        public async Task EditJobTitle(int JobTitleID, JobTitleDTO jobTitleDTO)
        {
            var jobTitle = new JobTitle
            {
                JobName = jobTitleDTO.JobName,
                JobSalary = jobTitleDTO.JobSalary

            };

            _logger.LogInformation("Updating the JObTitle Data");
            await _jobTitleService.Update(JobTitleID, jobTitle);
        }
    }
}

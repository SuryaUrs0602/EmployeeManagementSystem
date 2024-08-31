using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.DTO;
using EmployeeManagementSystem.Repositories.Contracts;
using EmployeeManagementSystem.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository departmentRepository, ILogger<DepartmentService> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }

        public async Task Add(Department obj)
        {
            try
            {
                _logger.LogInformation("Attempting to create new department");
                await _departmentRepository.Add(obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error Occured while creating Department");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while creating Department");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while creating Department");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Delete(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting to delete department");
                await _departmentRepository.Delete(ID);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error Occured while deleting Department");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while deleting Department");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while deleting Department");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetDepartmentDTO>> DepartmentInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch departments in ascending order");
                var data = await _departmentRepository.AscendingOrder();
                return data.Select(x => new GetDepartmentDTO
                {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<GetDepartmentDTO>> DepartmentInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch departments in descending order");
                var data = await _departmentRepository.DescndingOrder();
                return data.Select(x => new GetDepartmentDTO
                {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName
                });
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department data");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting Fetching all department details");
                return await _departmentRepository.GetAll();
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching all Departments");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching all Departments");
                throw new InvalidOperationException("Could not process due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while fetching All Departments");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task<Department> GetByID(object ID)
        {
            try
            {
                _logger.LogInformation("Attempting Fetching Department data by ID");
                return await _departmentRepository.GetByID(ID);
            }

            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department by ID");
                throw new InvalidOperationException("Could not proccess due to some error");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while fetching Department by ID");
                throw new Exception("Could not process due to some error");
            }
        }

        public async Task Update(object ID, Department obj)
        {
            try
            {
                _logger.LogInformation("Attempting to update Department data");
                await _departmentRepository.Update(ID, obj);
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error Occured while updating Department");
                throw new InvalidOperationException("Could not process due to some error!!!");
            }

            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Error Occured while updating Department");
                throw new InvalidOperationException("could not process due to some error!!!");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while updating Department");
                throw new Exception("Could not process due to some error");
            }
        }
    }
}

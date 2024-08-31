using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetEmployeeByProjectDTO
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePhoneNumber { get; set; }

        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public int ProjectDuration { get; set; }
    }
}

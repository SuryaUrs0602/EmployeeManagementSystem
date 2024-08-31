using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetEmployeeByJobTitleDTO
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePhoneNumber { get; set; }

        public int JobTitleID { get; set; }

        public string JobName { get; set; }

        public double JobSalary { get; set; }
    }
}

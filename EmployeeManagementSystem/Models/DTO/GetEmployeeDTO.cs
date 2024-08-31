using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetEmployeeDTO
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeePhoneNumber { get; set; }

        public int DepartmentID { get; set; }

        public int JobTitleID { get; set; }

        public int ProjectID { get; set; }
 
    }
}

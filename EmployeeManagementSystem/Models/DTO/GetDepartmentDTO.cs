using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetDepartmentDTO
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }
    }
}

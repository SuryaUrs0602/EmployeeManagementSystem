using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetEventDTO
    {
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }
    }
}

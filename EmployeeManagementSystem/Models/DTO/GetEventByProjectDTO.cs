using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetEventByProjectDTO
    {
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }
 
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public int ProjectDuration { get; set; }
    }
}

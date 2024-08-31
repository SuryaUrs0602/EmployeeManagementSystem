using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetProjectDTO
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public int ProjectDuration { get; set; }

    }
}

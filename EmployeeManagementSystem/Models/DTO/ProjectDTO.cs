using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class ProjectDTO
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string ProjectName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter a valid Duration")]
        public int ProjectDuration { get; set; }
    }
}

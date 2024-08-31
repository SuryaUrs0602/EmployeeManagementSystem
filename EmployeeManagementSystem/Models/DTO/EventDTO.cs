using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class EventDTO
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(15)]
        public string TaskStatus { get; set; }

        public int ProjectID { get; set; }
    }
}

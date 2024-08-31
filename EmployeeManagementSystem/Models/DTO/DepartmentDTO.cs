using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(30)]
        public string Name { get; set; }
    }
}

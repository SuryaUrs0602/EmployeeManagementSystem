using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class EmployeeDTO
    {

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(50)]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [StringLength(50)]
        public string EmployeeEmail { get; set; }


        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong Phone Number")]
        public string EmployeePhoneNumber { get; set; }


        public int DepartmentID { get; set; }


        public int JobTitleID { get; set; }


        public int ProjectID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models.DTO
{
    public class GetJobTitleDTO
    {
        public int JobTitleID { get; set; }

        public string JobName { get; set; }

        public double JobSalary { get; set; }

    }
}

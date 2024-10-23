using System.ComponentModel.DataAnnotations;

namespace Task1.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

     
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Roles { get; set; }


        /*
        public AttendanceDto Attendance { get; set; }
        public SalaryDto Salary { get; set; }
        */

    }
}

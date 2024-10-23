using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models.DTO
{
    public class addUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Roles { get; set; }

        /*
        [Required]
        public Guid SalaryId { get; set; }

        [Required]
        public Guid AttendanceId { get; set; }
        */

    }
}

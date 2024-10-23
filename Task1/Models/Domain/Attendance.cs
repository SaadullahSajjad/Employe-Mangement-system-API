using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models.Domain
{
  
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public int? TotalHoursWorked { get; set; } 

        public string AttendanceStatus { get; set; }


        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User user { get; set; }


    }
}

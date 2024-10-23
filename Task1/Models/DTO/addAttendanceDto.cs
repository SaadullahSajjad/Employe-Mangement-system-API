namespace Task1.Models.DTO
{
    public class addAttendanceDto
    {

        public Guid Id { get; set; }
        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public int? TotalHoursWorked { get; set; }

        public string AttendanceStatus { get; set; }

        public Guid UserId { get; set; }
    }
}

namespace Task1.Models.DTO
{
    public class updateAttendanceDto
    {
        public DateTime AttendanceDate { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public int? TotalHoursWorked { get; set; }

        public string AttendanceStatus { get; set; }
    }
}

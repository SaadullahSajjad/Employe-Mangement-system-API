using Task1.Models.Domain;

namespace Task1.Models.DTO
{
    public class UserLeaveDto
    {
        public Guid Id { get; set; }

        public int? AllowedLeaves { get; set; }

        public string? LeaveStatus { get; set; }

        public string? Reason { get; set; }

        public User user { get; set; }
    }
}

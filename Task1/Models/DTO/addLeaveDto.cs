using Task1.Models.Domain;

namespace Task1.Models.DTO
{
    public class addLeaveDto
    {
        public int? AllowedLeaves { get; set; }

        public string? LeaveStatus { get; set; }

        public string? Reason { get; set; }

        public Guid UserId { get; set; }
    }
}

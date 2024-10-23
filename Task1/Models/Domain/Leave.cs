using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models.Domain
{
    public class Leave
    {
        public Guid Id { get; set; }

        public int? AllowedLeaves { get; set; }

        public string? LeaveStatus { get; set; }

        public string? Reason { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User user { get; set; }
    }
}

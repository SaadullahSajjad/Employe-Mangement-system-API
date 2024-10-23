using Task1.Models.Domain;

namespace Task1.Repositories
{
    public interface ILeaveRepository
    {
        Task<List<Leave>> GetAllUserLeave();

        Task<Leave> StoreSingleUserLeave(Leave leave);

        Task<Leave?> GetSingleUserLeaveById(Guid id);

        Task<Leave?> UpdateUserLeaveById(Guid id, Leave leave);
        Task<Leave?> DeleteUserLeaveById(Guid id);

        Task<List<Leave>> GetLeavesByUserId(Guid id);

        
    }
}

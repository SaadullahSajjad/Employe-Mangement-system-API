using Microsoft.EntityFrameworkCore;
using Task1.DataBase;
using Task1.Models.Domain;

namespace Task1.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {

        private readonly UserInfoDBContext userInfoDBContext;
        public LeaveRepository(UserInfoDBContext userInfoDBContext)
        {

            this.userInfoDBContext = userInfoDBContext;
        }
        public async Task<Leave?> DeleteUserLeaveById(Guid id)
        {
            var exsitingUserLeave = await userInfoDBContext.Leaves.FirstOrDefaultAsync(x => x.Id == id);

            if (exsitingUserLeave == null)
            {
                return null;
            }

            userInfoDBContext.Leaves.Remove(exsitingUserLeave);

            await userInfoDBContext.SaveChangesAsync();
            return exsitingUserLeave;
        }


        public async Task<List<Leave>> GetAllUserLeave()
        {
            return await userInfoDBContext.Leaves.Include(u => u.user).ToListAsync();
        }

        public async Task<List<Leave>> GetLeavesByUserId(Guid id)
        {
            return await userInfoDBContext.Leaves.Include(u => u.user).Where(u => u.UserId == id).ToListAsync();
        }

        public async Task<Leave?> GetSingleUserLeaveById(Guid id)
        {
            return await userInfoDBContext.Leaves.Include(u => u.user).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Leave> StoreSingleUserLeave(Leave leave)
        {
            await userInfoDBContext.Leaves.AddAsync(leave);
            await userInfoDBContext.SaveChangesAsync();

            return leave;
        }

        public async Task<Leave?> UpdateUserLeaveById(Guid id, Leave leave)
        {
            var existingLeave = userInfoDBContext.Leaves.FirstOrDefault(x => x.Id == id);
            if (existingLeave == null)
            {
                return null;
            }

            existingLeave.LeaveStatus = leave.LeaveStatus;
            existingLeave.AllowedLeaves = leave.AllowedLeaves;
            existingLeave.Reason = leave.Reason;

            await userInfoDBContext.SaveChangesAsync();
            return existingLeave;
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Task1.DataBase;
using Task1.Models.Domain;

namespace Task1.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {

        private readonly UserInfoDBContext userInfoDBContext;
        public AttendanceRepository(UserInfoDBContext userInfoDBContext)
        {

            this.userInfoDBContext = userInfoDBContext;
        }
        public async Task<Attendance?> DeleteUserAttendanceById(Guid id)
        {
              var exsitingUserAttendance = await userInfoDBContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);

              if (exsitingUserAttendance == null)
              {
                  return null;
              }

              userInfoDBContext.Attendances.Remove(exsitingUserAttendance);

              await userInfoDBContext.SaveChangesAsync();
            
            return exsitingUserAttendance;
          }

            public async Task<List<Attendance>> GetAllUserAttendance()
        {
            return await userInfoDBContext.Attendances.Include(u => u.user).ToListAsync();
            
        }

        public async Task<Attendance?> GetSingleUserAttendanceById(Guid id)
        {
            return await userInfoDBContext.Attendances.Include(u => u.user).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Attendance> StoreSingleUserAttendance(Attendance attendance)
        {
            await userInfoDBContext.Attendances.AddAsync(attendance);
            await userInfoDBContext.SaveChangesAsync();

            return attendance;
        }

        public async Task<Attendance?> UpdateSingleUserAttendanceById(Guid id, Attendance attendance)
        {
            var exsitingUserAttendance = userInfoDBContext.Attendances.FirstOrDefault(x => x.Id == id);

            if(exsitingUserAttendance == null) {

                return null;
            }

            exsitingUserAttendance.AttendanceDate = attendance.AttendanceDate;
            exsitingUserAttendance.AttendanceStatus = attendance.AttendanceStatus;
            exsitingUserAttendance.TotalHoursWorked = attendance.TotalHoursWorked;
            exsitingUserAttendance.CheckInTime = attendance.CheckInTime;
            exsitingUserAttendance.CheckOutTime = attendance.CheckOutTime;

            await userInfoDBContext.SaveChangesAsync();
            return exsitingUserAttendance;


        }
    }
}

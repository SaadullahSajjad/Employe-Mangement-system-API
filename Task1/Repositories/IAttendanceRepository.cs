using Task1.Models.Domain;

namespace Task1.Repositories
{
    public interface IAttendanceRepository
    {

        Task<List<Attendance>> GetAllUserAttendance();

        Task<Attendance> StoreSingleUserAttendance(Attendance attendance);

        Task<Attendance?> GetSingleUserAttendanceById(Guid id);

        Task<Attendance?> UpdateSingleUserAttendanceById(Guid id, Attendance attendance);

        Task<Attendance?> DeleteUserAttendanceById(Guid id);
    }
}

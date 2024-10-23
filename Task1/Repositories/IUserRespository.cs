using Task1.Models.Domain;

namespace Task1.Repositories
{
    public interface IUserRespository
    {
        Task<List<User>> GetAllUser();

        
        Task<User> StoreSingleUser(User user);

        Task<User?> GetSingleUserById(Guid id);
        
        Task<User?> DeleteUserById(Guid id);

        Task<List<Salary>> GetUserSalariesById(Guid id);

        Task<List<Attendance>> GetUserAttendancesById(Guid id);



    }
}


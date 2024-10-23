using Microsoft.EntityFrameworkCore;
using Task1.DataBase;
using Task1.Models.Domain;

namespace Task1.Repositories
{
    public class UserRepository : IUserRespository
    {
        private readonly UserInfoDBContext userInfoDBContext;
        
        
        public UserRepository( UserInfoDBContext userInfoDBContext) { 
        
            this.userInfoDBContext = userInfoDBContext;
           
            
        }


       
        
   public async Task<List<User>> GetAllUser()
    {

       return await userInfoDBContext.Users.ToListAsync();

    }

       

               public async Task<User?> GetSingleUserById(Guid id)
               {
                   return await userInfoDBContext.Users.FirstOrDefaultAsync(u => u.Id == id);

               }


       
                  public async Task<User> StoreSingleUser(User user)
                  {
              userInfoDBContext.Database.SetCommandTimeout(180);
              await userInfoDBContext.Users.AddAsync(user);
                      await userInfoDBContext.SaveChangesAsync();

                      //await userInfoDBContext.Entry(user).Reference(u => u.Salary).LoadAsync();
                      //await userInfoDBContext.Entry(user).Reference(u => u.Attendance).LoadAsync();

                      return user;
                  }

       

             public async Task<User?> DeleteUserById(Guid id)
             {

                 var exsitingUser = await userInfoDBContext.Users.FirstOrDefaultAsync(x => x.Id == id);

                 if (exsitingUser == null)
                 {
                     return null; 
                 }

                  userInfoDBContext.Users.Remove(exsitingUser);

                 await userInfoDBContext.SaveChangesAsync();
                 return exsitingUser;

             }

        public async Task<List<Salary>> GetUserSalariesById(Guid id)
        {
            return await userInfoDBContext.Salarys.Include(u => u.user).Where(u => u.UserId == id).ToListAsync();


        }

        public async Task<List<Attendance>> GetUserAttendancesById(Guid id)
        {
            return await userInfoDBContext.Attendances.Include(u => u.user).Where(u => u.UserId == id).ToListAsync();
        }
    }
}





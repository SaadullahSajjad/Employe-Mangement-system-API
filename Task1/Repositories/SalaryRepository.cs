using Microsoft.EntityFrameworkCore;
using Task1.DataBase;
using Task1.Models.Domain;

namespace Task1.Repositories
{
    public class SalaryRepository : ISalarayRepository
    {

        private readonly UserInfoDBContext userInfoDBContext;
        public SalaryRepository(UserInfoDBContext userInfoDBContext)
        {

            this.userInfoDBContext = userInfoDBContext;
        }

        public async Task<Salary?> DeleteUserSalaryById(Guid id)
        {
            var exsitingUserSalary = await userInfoDBContext.Salarys.FirstOrDefaultAsync(x => x.Id == id);

            if (exsitingUserSalary == null)
            {
                return null;
            }

            userInfoDBContext.Salarys.Remove(exsitingUserSalary);

            await userInfoDBContext.SaveChangesAsync();
            return exsitingUserSalary;
        }

        public async Task<List<Salary>> GetAllUserSalary()
        {
            return await userInfoDBContext.Salarys.Include(u => u.user).ToListAsync();
        }

        public async Task<Salary?> GetSingleUserSalaryById(Guid id)
        {

            return await userInfoDBContext.Salarys.Include(u => u.user).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Salary> StoreSingleUserSalary(Salary salary)
        {
            await userInfoDBContext.Salarys.AddAsync(salary);
            await userInfoDBContext.SaveChangesAsync();

            return salary;
        }

        public async Task<Salary?> UpdateUserSalaryById(Guid id, Salary salary)
        {
            var existingSalary = userInfoDBContext.Salarys.FirstOrDefault(x => x.Id == id);
            if (existingSalary == null)
            {
                return null;
            }

            existingSalary.NetSalary = salary.NetSalary;
            existingSalary.Allowances = salary.Allowances;
            existingSalary.PayMethod = salary.PayMethod;

            await userInfoDBContext.SaveChangesAsync();
            return existingSalary;
        }
    }
}

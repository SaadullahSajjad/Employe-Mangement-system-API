using Task1.Models.Domain;

namespace Task1.Repositories
{
    public interface ISalarayRepository
    {

        Task<List<Salary>> GetAllUserSalary();

        Task<Salary> StoreSingleUserSalary(Salary salary);

        Task<Salary?> GetSingleUserSalaryById(Guid id);

        Task<Salary?> UpdateUserSalaryById(Guid id, Salary salary);
        Task<Salary?> DeleteUserSalaryById(Guid id);
    }
}

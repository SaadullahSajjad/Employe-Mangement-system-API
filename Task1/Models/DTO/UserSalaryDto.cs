using Task1.Models.Domain;

namespace Task1.Models.DTO
{
    public class UserSalaryDto
    {
        //public SalaryDto Salary { get; set; }
        public Guid Id { get; set; }


        public int NetSalary { get; set; }


        public string Allowances { get; set; }


        public string PayMethod { get; set; }

        public User user { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models.Domain
{
  
    public class Salary
    {
        
        public Guid Id { get; set; }

        public int NetSalary { get; set; }

        public string Allowances { get; set; }

        public string PayMethod { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }



        public User user { get; set; }


    }

}

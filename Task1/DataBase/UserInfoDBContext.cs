

using Microsoft.EntityFrameworkCore;
using Task1.Models.Domain;
using Task1.Convertor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Task1.DataBase
{
    public class UserInfoDBContext : DbContext
    {
        public UserInfoDBContext(DbContextOptions<UserInfoDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Salary> Salarys { get; set; }

        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

          
            var user = new List<User>()
  {
    new User
    {
        Id = Guid.Parse("c1415027-e627-4956-bf7b-d43e23feec06"),
        Name = "Ghufran",
        Email="gcch@gmail.com",
        Password = "1234567890",
        Roles="admin"
    },
    new User
    {
        Id = Guid.Parse("89b876cc-a901-4467-bb50-1a23389805af"),
        Name = "nomi",
        Email="nomi@gmail.com",
        Password = "1234567890",
        Roles="employee"
    },
    new User
    {
        Id = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537"),
        Name = "ali",
        Email="ali@gmail.com",
        Password = "1234567890",
        Roles="employee"
    }
            };


            modelBuilder.Entity<User>().HasData(user);


            var salary = new List<Salary>()
            {
                new Salary
                { 
                Id=Guid.Parse("36127359-6b07-4a62-a3a0-2d96581321e1"),
                NetSalary=20000,
                Allowances="Petrol incentives",
                PayMethod= "cash by Hand",
                UserId = Guid.Parse("89b876cc-a901-4467-bb50-1a23389805af")
                },
                new Salary
                {
                Id=Guid.Parse("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"),
                NetSalary=50000,
                Allowances="Bonus incentives",
                PayMethod= "cash by Hand"
                ,
                UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                },
                new Salary
                {
                Id=Guid.Parse("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"),
                NetSalary=30000,
                Allowances="Petrol incentives",
                PayMethod= "credit card",
                UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                }
            };

            modelBuilder.Entity<Salary>().HasData(salary);

            var attendance = new List<Attendance>()
{
    new Attendance
    {
        Id = Guid.Parse("d41cd31c-3fef-4c3c-9ebb-020a6c2dc256"),
        AttendanceDate = new DateTime(2023, 6, 15),
        CheckInTime = new DateTime(2023, 6, 15, 9, 0, 0),
        CheckOutTime = new DateTime(2023, 6, 15, 17, 0, 0),
        TotalHoursWorked = 8,
        AttendanceStatus = "Present",
        UserId = Guid.Parse("89b876cc-a901-4467-bb50-1a23389805af")
    },
    new Attendance
    {
        Id = Guid.Parse("39fcf329-d915-4c75-ab57-1cd4c1270788"),
        AttendanceDate = new DateTime(2023, 6, 16),
        CheckInTime = new DateTime(2023, 6, 16, 9, 0, 0),
        CheckOutTime = new DateTime(2023, 6, 16, 17, 0, 0),
        TotalHoursWorked = 7,
        AttendanceStatus = "Late",
         UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
    },
    new Attendance
    {
        Id = Guid.Parse("29f73ba9-a5d3-4280-9580-0f3e4f9aac06"),
        AttendanceDate = new DateTime(2023, 6, 17),
        CheckInTime = new DateTime(2023, 6, 17, 9, 0, 0),
        CheckOutTime = new DateTime(2023, 6, 17, 16, 0, 0),
        TotalHoursWorked = 7,
        AttendanceStatus = "Present",
        UserId = Guid.Parse("89b876cc-a901-4467-bb50-1a23389805af")
    },
    new Attendance
    {
        Id = Guid.Parse("2f2763d3-a4d4-4d8b-b199-800882a1c601"),
        AttendanceDate = new DateTime(2023, 6, 18),
        CheckInTime = new DateTime(2023, 6, 18, 10, 0, 0),
        CheckOutTime = new DateTime(2023, 6, 18, 17, 0, 0),
        TotalHoursWorked = 6,
        AttendanceStatus = "Late",
         UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
    }
};


            modelBuilder.Entity<Attendance>().HasData(attendance);


            var leave = new List<Leave>()
            {
                new Leave
                {
                Id=Guid.Parse("36127359-6b07-4a62-a3a0-2d96581321e1"),
                AllowedLeaves=5,
                LeaveStatus="Approved",
                Reason= "fever",
                UserId = Guid.Parse("89b876cc-a901-4467-bb50-1a23389805af")
                },
                new Leave
                {
                Id=Guid.Parse("2ca6bfc2-4fa5-4e59-81d9-e52acaca096a"),
               AllowedLeaves=5,
                LeaveStatus="Pending",
                Reason= "fever",
                
                UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                },
                new Leave
                {
                Id=Guid.Parse("9c3f9bf9-3680-4c5a-a3d4-bd1969dec093"),
               AllowedLeaves=5,
                LeaveStatus="disApproved",
                Reason= "fever",
                UserId = Guid.Parse("3f470b47-eab2-4eca-a78c-44f1b62c1537")
                }
            };

            modelBuilder.Entity<Leave>().HasData(leave);




        }
    }
}





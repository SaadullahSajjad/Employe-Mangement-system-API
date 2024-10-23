using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Roles { get; set; }


    }
}



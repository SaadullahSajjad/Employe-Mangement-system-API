namespace Task1.Models.DTO
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string JwtToken { get; set; }

        public string Name { get; set; }

        
        public string Email { get; set; }

       
        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.DataBase;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

      
        private readonly ITokenRepository tokenRepository;
        private readonly UserInfoDBContext userInfoDBContext;

        public AuthController( ITokenRepository tokenRepository,UserInfoDBContext userInfoDBContext)
        {
           
            this.tokenRepository = tokenRepository;
            this.userInfoDBContext = userInfoDBContext;
        }




   


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {


            var exsitingUser = await userInfoDBContext.Users.FirstOrDefaultAsync(x => x.Email == loginRequestDto.Email);

            if (exsitingUser == null)
            {
                return BadRequest("User not found");
            }

            if(exsitingUser.Email == loginRequestDto.Email && exsitingUser.Password == loginRequestDto.Password) {


                var jwtToken = tokenRepository.CreateJWTToken(exsitingUser);

                var response = new LoginResponseDto
                {
                    Id = exsitingUser.Id,
                    JwtToken = jwtToken,
                    Name = exsitingUser.Name,
                    Email =exsitingUser.Email,
                    Password = exsitingUser.Password,
                    UserRole = exsitingUser.Roles

                };

                return Ok(response);

            }



            /*
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);


            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var jwtToken = tokenRepository.CreateJWTToken(user);

                    var response = new LoginResponseDto
                    {
                        JwtToken = jwtToken
                    };

                    return Ok(response);

                }

            }


            */
            return BadRequest("Username or password incorrect");






        }




    }
}







/*
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] registerRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                return Ok("User was registered! Please login.");
            }

            return BadRequest("Something went wrong");

        }
        

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {

            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);


            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                        var jwtToken = tokenRepository.CreateJWTToken(user);

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    
                }

            }

            return BadRequest("Username or password incorrect");




        }




    }
}


*/


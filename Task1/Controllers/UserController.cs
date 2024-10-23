
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task1.Models.Domain;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRespository userRespository;
        private readonly IMapper mapper;

        public UserController(IUserRespository userRespository, IMapper mapper)
        {
            this.userRespository = userRespository;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {

            var userDomainModel = await userRespository.GetAllUser();



            return Ok(mapper.Map<List<UserDto>>(userDomainModel));


        }




        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] addUserDto addUserDto)
        {
            try
            {


                var userDomainModel = mapper.Map<User>(addUserDto);

                var createdUser = await userRespository.StoreSingleUser(userDomainModel);

                return Ok(mapper.Map<UserDto>(createdUser));


            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "An error occurred while saving the entity changes.",
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException?.Message
                };

                return BadRequest(errorResponse);
            }


        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var userDomianModel = await userRespository.GetSingleUserById(id);

            if (userDomianModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomianModel));
        }


        [HttpGet]
        [Route("Salary/{id:Guid}")]
        public async Task<IActionResult> GetUserSalariesById([FromRoute] Guid id)
        {
            var userSalariesDomianModel = await userRespository.GetUserSalariesById(id);

            if (userSalariesDomianModel == null || userSalariesDomianModel.Count == 0)
            {
                return NotFound();
            }


            return Ok(mapper.Map<List<UserSalaryDto>>(userSalariesDomianModel));
        }


        [HttpGet]
        [Route("Attendance/{id:Guid}")]
        public async Task<IActionResult> GetUserAttendancesById([FromRoute] Guid id)
        {
            var userAttendanceDomianModel = await userRespository.GetUserAttendancesById(id);

            if (userAttendanceDomianModel == null || userAttendanceDomianModel.Count == 0)
            {
                return NotFound();
            }


           // return Ok(mapper.Map<AttendanceDto>(userAttendanceDomianModel));
            return Ok((userAttendanceDomianModel));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id)
        {

            var deleteUserDomainModel = await userRespository.DeleteUserById(id);

            if (deleteUserDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(deleteUserDomainModel));

        }



    }
}




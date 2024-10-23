using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task1.Models.Domain;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        
        private readonly IMapper mapper;
        private readonly ILeaveRepository leaveRepository;

        public LeaveController( IMapper mapper,ILeaveRepository leaveRepository)
        {
            
            this.mapper = mapper;
            this.leaveRepository = leaveRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersLeave()
        {

            var leaveDomainModel = await leaveRepository.GetAllUserLeave();

            return Ok(mapper.Map<List<LeaveDto>>(leaveDomainModel));

        }

        [HttpPost]
        public async Task<IActionResult> CreateUserLeave([FromBody] addLeaveDto addLeaveDto)
        {
            var leaveDomainModel = mapper.Map<Leave>(addLeaveDto);

            var createdUserLeave = await leaveRepository.StoreSingleUserLeave(leaveDomainModel);

            return Ok(mapper.Map<LeaveDto>(createdUserLeave));
        }


        [HttpGet]
        [Route("{id:Guid}")]
        // [Authorize]
        public async Task<IActionResult> GetUserLeaveById([FromRoute] Guid id)
        {
            var userLeaveDomianModel = await leaveRepository.GetSingleUserLeaveById(id);

            if (userLeaveDomianModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<LeaveDto>(userLeaveDomianModel));
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updaterLeaveById([FromRoute] Guid id, [FromBody] updateLeaveDto updateLeaveDto)
        {
            var leaveDomainModel = mapper.Map<Leave>(updateLeaveDto);

            leaveDomainModel = await leaveRepository.UpdateUserLeaveById(id, leaveDomainModel);

            // If Null then NotFound
            if (leaveDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to Dto
            var LeaveDto = mapper.Map<LeaveDto>(leaveDomainModel);

            return Ok(LeaveDto);


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUserLeaveById([FromRoute] Guid id)
        {

            var deleteUserLeaveDomainModel = await leaveRepository.DeleteUserLeaveById(id);
            if (deleteUserLeaveDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LeaveDto>(deleteUserLeaveDomainModel));

        }

        [HttpGet]
        [Route("User/{id:Guid}")]
        public async Task<IActionResult> GetUserSalariesById([FromRoute] Guid id)
        {
            var userLeavesDomianModel = await leaveRepository.GetLeavesByUserId(id);

            if (userLeavesDomianModel == null || userLeavesDomianModel.Count == 0)
            {
                return NotFound();
            }


            return Ok(mapper.Map<List<UserLeaveDto>>(userLeavesDomianModel));
        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task1.Models.Domain;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{

    


    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IMapper mapper;
        public AttendanceController(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            this.attendanceRepository = attendanceRepository;
            this.mapper = mapper;
        }


       
        


        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllUsersAttendance()
        {

            var attendanceDomainModel = await attendanceRepository.GetAllUserAttendance();



            return Ok(mapper.Map<List<AttendanceDto>>(attendanceDomainModel));


        }



        [HttpPost]
        public async Task<IActionResult> CreateUserAttendance([FromBody] addAttendanceDto addAttendanceDto)
        {
            var attendanceDomainModel = mapper.Map<Attendance>(addAttendanceDto);

           
           
/*
            attendanceDomainModel.AttendanceDate = DateOnlyConverter(addAttendanceDto.AttendanceDate);
    attendanceDomainModel.CheckInTime = TimeOnlyConverter(addAttendanceDto.CheckInTime);
    attendanceDomainModel.CheckOutTime = TimeOnlyConverter(addAttendanceDto.CheckOutTime);


             DateOnly DateOnlyConverter(DateTime dateTime)
            {
                return DateOnly.FromDateTime(dateTime);
            }

             TimeOnly TimeOnlyConverter(DateTime dateTime)
            {
                return TimeOnly.FromDateTime(dateTime);
            }


            */

            var createdUserAttendance = await attendanceRepository.StoreSingleUserAttendance(attendanceDomainModel);

            return Ok(mapper.Map<AttendanceDto>(createdUserAttendance));
        }


       

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserAttendanceById([FromRoute] Guid id)
        {
            var userAttendanceDomianModel = await attendanceRepository.GetSingleUserAttendanceById(id);

            if (userAttendanceDomianModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<AttendanceDto>(userAttendanceDomianModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdatetUserAttendanceById([FromRoute] Guid id, [FromBody] updateAttendanceDto updateAttendanceDto)
        {

            var AttendanceDomainModel = mapper.Map<Attendance>(updateAttendanceDto);

            AttendanceDomainModel = await attendanceRepository.UpdateSingleUserAttendanceById(id, AttendanceDomainModel);

            // If Null then NotFound
            if (AttendanceDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to Dto
            var AttendanceDto = mapper.Map<AttendanceDto>(AttendanceDomainModel);

            return Ok(AttendanceDto);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUserAttendanceById([FromRoute] Guid id)
        {

            var deleteUserAttendanceDomainModel = await attendanceRepository.DeleteUserAttendanceById(id);

            if (deleteUserAttendanceDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AttendanceDto>(deleteUserAttendanceDomainModel));

        }



    }
}




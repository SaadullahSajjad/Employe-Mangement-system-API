using AutoMapper;
using Task1.Models.Domain;
using Task1.Models.DTO;

namespace Task1.Mappings
{
    public class AutoMapping: Profile
    {

        public AutoMapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, addUserDto>().ReverseMap();
            CreateMap<UserDto, addUserDto>().ReverseMap();
            CreateMap<addUserDto, UserDto>().ReverseMap();

            CreateMap<Salary, UserSalaryDto>().ReverseMap();
            CreateMap<Attendance, UserAttendanceDto>().ReverseMap();
            CreateMap<AttendanceDto, UserAttendanceDto>().ReverseMap();


            CreateMap<Salary, SalaryDto>().ReverseMap();
            CreateMap<addSalaryDto, Salary>().ReverseMap();
            CreateMap<addSalaryDto, SalaryDto>().ReverseMap();
            CreateMap<updateSalaryDto, SalaryDto>().ReverseMap();
            CreateMap<updateSalaryDto, Salary>().ReverseMap();


            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<addAttendanceDto, Attendance>().ReverseMap();
            CreateMap<addAttendanceDto, AttendanceDto>().ReverseMap();
            CreateMap<updateAttendanceDto, AttendanceDto>().ReverseMap();
            CreateMap<updateAttendanceDto, Attendance>().ReverseMap();


            CreateMap<Leave, LeaveDto>().ReverseMap();
            CreateMap<Leave, addLeaveDto>().ReverseMap();
            CreateMap<Leave, updateLeaveDto>().ReverseMap();
            CreateMap<Leave, UserLeaveDto>().ReverseMap();


        }

    }
}

/*b867ed03-3fd1-4eab-70f1-08dc9a181447
 */
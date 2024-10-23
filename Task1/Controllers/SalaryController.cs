using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task1.Models.Domain;
using Task1.Models.DTO;
using Task1.Repositories;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : Controller
    {
        private readonly ISalarayRepository salarayRepository;
        private readonly IMapper mapper;
        public SalaryController(ISalarayRepository salarayRepository , IMapper mapper)
        {
            this.salarayRepository = salarayRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsersSalary()
        {

            var salaryDomainModel = await salarayRepository.GetAllUserSalary();



            return Ok(mapper.Map<List<SalaryDto>>(salaryDomainModel));


        }



        [HttpPost]
        public async Task<IActionResult> CreateUserSalary([FromBody] addSalaryDto addSalaryDto)
        {
            var salaryDomainModel = mapper.Map<Salary>(addSalaryDto);

            var createdUserSalary = await salarayRepository.StoreSingleUserSalary(salaryDomainModel);

            return Ok(mapper.Map<SalaryDto>(createdUserSalary));
        }


        [HttpGet]
        [Route("{id:Guid}")]
       // [Authorize]
        public async Task<IActionResult> GetUserSalaryById([FromRoute] Guid id)
        {
            var userSalaryDomianModel = await salarayRepository.GetSingleUserSalaryById(id);

            if (userSalaryDomianModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<SalaryDto>(userSalaryDomianModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updaterSalaryById([FromRoute] Guid id, [FromBody] updateSalaryDto updateSalaryDto)
        {
            var SalaryDomainModel = mapper.Map<Salary>(updateSalaryDto);

            SalaryDomainModel = await salarayRepository.UpdateUserSalaryById(id, SalaryDomainModel);

            // If Null then NotFound
            if (SalaryDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to Dto
            var RegionDto = mapper.Map<SalaryDto>(SalaryDomainModel);

            return Ok(RegionDto);


        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUserSalaryById([FromRoute] Guid id)
        {
            
                var deleteUserSalaryDomainModel = await salarayRepository.DeleteUserSalaryById(id);
                if (deleteUserSalaryDomainModel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<SalaryDto>(deleteUserSalaryDomainModel));

        }








    }
}

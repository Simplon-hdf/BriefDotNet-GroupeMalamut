using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PenseeController : ControllerBase
	{
        private readonly IController<Guid, PenseeDto> penseeService;
        public PenseeController(IController<Guid, PenseeDto> service)


        {
            penseeService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PenseeDto>>> GetAllRandonneurs()
        {
            var result = await penseeService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PenseeDto>> GetRandonneurById(Guid id)
        {
            var result = await penseeService.GetById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<PenseeDto>>> AddRole(PenseeDto randonneur)
        {
            var result = await penseeService.Add(randonneur);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PenseeDto>>> DeleteRole(Guid id)
        {
            var result = await penseeService.DeleteById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<PenseeDto>>> Update(Guid id, PenseeDto randonneur)
        {
            var result = await penseeService.Update(id, randonneur);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

    }


}


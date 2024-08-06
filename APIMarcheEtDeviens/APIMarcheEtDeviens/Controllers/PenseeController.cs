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
        private readonly IController<Guid, Pensee> penseeService;
        public PenseeController(IController<Guid, Pensee> service)


        {
            penseeService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pensee>>> GetAllRandonneurs()
        {
            var result = await penseeService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pensee>> GetRandonneurById(Guid id)
        {
            var result = await penseeService.GetById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Pensee>>> AddRole(Pensee randonneur)
        {
            var result = await penseeService.Add(randonneur);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pensee>>> DeleteRole(Guid id)
        {
            var result = await penseeService.DeleteById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Pensee>>> Update(Guid id, Pensee randonneur)
        {
            var result = await penseeService.Update(id, randonneur);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

    }


}


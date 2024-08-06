using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandonneurController : ControllerBase
	{
		private readonly IController<Guid, Randonneur> randonneurService;
        public RandonneurController(IController<Guid, Randonneur> service)
		
		
		{
			 randonneurService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<Randonneur>>> GetAllRandonneurs()
		{
			var result = await randonneurService.GetAll();

			return Ok(result);
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<Randonneur>> GetRandonneurById(Guid id)
        {
            var result = await randonneurService.GetById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<Randonneur>>> AddRole(Randonneur randonneur)
        {
            var result = await randonneurService.Add(randonneur);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Randonneur>>> DeleteRole(Guid id)
        {
            var result = await randonneurService.DeleteById(id);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Randonneur>>> Update(Guid id, Randonneur randonneur)
        {
            var result = await randonneurService.Update(id, randonneur);
            if (result is null)
                return NotFound("Role not found");

            return Ok(result);
        }

    }
}


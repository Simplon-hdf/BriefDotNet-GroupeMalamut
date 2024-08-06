using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandoneeController : ControllerBase
	{
		private readonly IController<Guid, Randonnee> randonneeService;
		public RandoneeController(IController<Guid, Randonnee> service)
		{
			randonneeService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<Role>>> GetAllRandonne()
		{
			var result = await randonneeService.GetAll();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Role>> GetRandonneById(Guid id)
		{
			var result = await randonneeService.GetById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPost]

		public async Task<ActionResult<List<Randonnee>>> AddRandonne(Randonnee randonnee)
		{
			var result = await randonneeService.Add(randonnee);
			if (result is null)
				return BadRequest();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Role>>> DeleteRandonne(Guid id)
		{
			var result = await randonneeService.DeleteById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<Role>>> Update(Guid id, Randonnee randonnee)
		{
			var result = await randonneeService.Update(id, randonnee);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}


	}
}


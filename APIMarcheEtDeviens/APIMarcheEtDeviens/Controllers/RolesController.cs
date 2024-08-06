using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IController<int, Role> roleService;
		public RolesController(IController<int, Role> service)
		{
			roleService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<Role>>> GetAllRoles()
		{
			var result = await roleService.GetAll();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Role>> GetRoleById(int id)
		{
			var result = await roleService.GetById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPost]

		public async Task<ActionResult<List<Role>>> AddRole(Role role)
		{
			var result = await roleService.Add(role);
			if (result is null)
				return BadRequest();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Role>>> DeleteRole(int id)
		{
			var result = await roleService.DeleteById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<Role>>> Update(int id, Role role)
		{
			var result = await roleService.Update(id, role);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}
	}
}


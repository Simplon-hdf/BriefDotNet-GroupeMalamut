using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IController<int, RoleDto> roleService;
		public RolesController(IController<int, RoleDto> service)
		{
			roleService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
		{
			var result = await roleService.GetAll();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RoleDto>> GetRoleById(int id)
		{
			var result = await roleService.GetById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPost]

		public async Task<ActionResult<List<RoleDto>>> AddRole(RoleDto role)
		{
			var result = await roleService.Add(role);
			if (result is null)
				return BadRequest();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<RoleDto>>> DeleteRole(int id)
		{
			var result = await roleService.DeleteById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<RoleDto>>> Update(int id, RoleDto role)
		{
			var result = await roleService.Update(id, role);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}
	}
}


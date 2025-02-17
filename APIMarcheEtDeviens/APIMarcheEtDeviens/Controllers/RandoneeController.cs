﻿using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using APIMarcheEtDeviens.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class RandoneeController : ControllerBase
	{
		private readonly IController<Guid, RandonneeDto> randonneeService;

		public RandoneeController(IController<Guid, RandonneeDto> service)
		{
			randonneeService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<RandonneeDto>>> GetAllRandonne()
		{
			var result = await randonneeService.GetAll();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RandonneeDto>> GetRandonneById(Guid id)
		{
			var result = await randonneeService.GetById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}


		[HttpPost]

		public async Task<ActionResult<List<RandonneeDto>>> AddRandonne(RandonneeDto randonnee)
		{
			var result = await randonneeService.Add(randonnee);
			if (result is null)
				return BadRequest();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<RandonneeDto>>> DeleteRandonne(Guid id)
		{
			var result = await randonneeService.DeleteById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<RandonneeDto>>> Update(Guid id, RandonneeDto randonnee)
		{
			var result = await randonneeService.Update(id, randonnee);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}


	}
}


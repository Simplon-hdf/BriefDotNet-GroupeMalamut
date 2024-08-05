﻿using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandoneeController : ControllerBase
	{
		private readonly DataContext _context;
		public RandoneeController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Randonnee>>> GetAllRandonnees()
		{
			var randonnees = await _context.Randonnee.ToListAsync();

			return Ok(randonnees);
		}

		
	}
}

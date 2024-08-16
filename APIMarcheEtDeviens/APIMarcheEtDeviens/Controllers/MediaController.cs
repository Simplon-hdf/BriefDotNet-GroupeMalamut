using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using APIMarcheEtDeviens.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class MediaController : ControllerBase
	{
		private readonly IController<Guid, MediaDto> mediaService;
		public MediaController(IController<Guid, MediaDto> service)
		{
			mediaService = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<MediaDto>>> GetAllMedias()
		{
			var medias = await mediaService.GetAll();

			return Ok(medias);
		}

		[HttpGet("{id}")]

		public async Task<ActionResult<List<MediaDto>>> GetMediaById(Guid id)
		{
			var result = await mediaService.GetById(id);
			if (result is null)
				return NotFound("Media not found...");
			return Ok(result);
		}
		
		[HttpPost]
		
		public async Task<ActionResult<List<MediaDto>>> AddMedia(MediaDto media)
		{
			var result = await mediaService.Add(media);
			if (result is null)
				return NotFound("Media not found...");
			return Ok(result);
		}
		
		[HttpDelete("{id}")]
		public async Task<ActionResult<List<MediaDto>>> DeleteMedia(Guid id)
		{
			var result = await mediaService.DeleteById(id);
			if (result is null)
				return NotFound("Media not found...");
			return Ok(result);
		}
		
		[HttpPut]
		
		public async Task<ActionResult<List<MediaDto>>> UpdateMedia(Guid id, MediaDto media)
		{
			var result = await mediaService.Update(id, media);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		
	}
}

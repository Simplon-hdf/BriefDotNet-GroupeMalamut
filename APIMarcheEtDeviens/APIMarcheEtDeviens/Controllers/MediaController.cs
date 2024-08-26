using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using APIMarcheEtDeviens.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
    // Définition de la route de base pour ce contrôleur
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        // Déclaration du service de gestion des médias
        private readonly IController<Guid, MediaDto> mediaService;

        // Constructeur du contrôleur, injection du service de gestion des médias
        public MediaController(IController<Guid, MediaDto> service)
        {
            mediaService = service;
        }

        // Endpoint pour récupérer tous les médias
        [HttpGet]
        public async Task<ActionResult<List<MediaDto>>> GetAllMedias()
        {
            var medias = await mediaService.GetAll();
            return Ok(medias);
        }

        // Endpoint pour récupérer un média par son ID
        [HttpGet("{id}")]
        public async Task<ActionResult<List<MediaDto>>> GetMediaById(Guid id)
        {
            var result = await mediaService.GetById(id);
            if (result is null)
                return NotFound("Media not found...");
            return Ok(result);
        }

        // Endpoint pour ajouter un nouveau média
        [HttpPost]
        public async Task<ActionResult<List<MediaDto>>> AddMedia(MediaDto media)
        {
            var result = await mediaService.Add(media);
            if (result is null)
                return NotFound("Media not found...");
            return Ok(result);
        }

        // Endpoint pour supprimer un média par son ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MediaDto>>> DeleteMedia(Guid id)
        {
            var result = await mediaService.DeleteById(id);
            if (result is null)
                return NotFound("Media not found...");
            return Ok(result);
        }

        // Endpoint pour mettre à jour un média existant
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
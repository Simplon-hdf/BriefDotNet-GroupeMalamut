using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace APIMarcheEtDeviens.Repository
{
    public class MediaService : IController<Guid, MediaDto>

    {
        private readonly DataContext _DbContext;
        public MediaService(DataContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<MediaDto>?> GetAll()
        {
            var medias = _DbContext.Media.Select(media => _mapper.Map<MediaDto>(media)).ToList();
            return medias;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<MediaDto?> GetById(Guid id)
        {
            var mediaResult = _DbContext.Media.Find(id);
            if (mediaResult == null)
                return null;

            var dtoResult = new MediaDto();
            dtoResult.TypeMedia = mediaResult.TypeMedia;
            dtoResult.CheminDuMedia = mediaResult.CheminDuMedia;
            dtoResult.NomMedia = mediaResult.NomMedia;

            return dtoResult;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<MediaDto>> Add(MediaDto media)
        {
            Media mediaInput = new Media();

            mediaInput.CheminDuMedia = media.CheminDuMedia;
            mediaInput.NomMedia = media.NomMedia;
            mediaInput.TypeMedia = media.TypeMedia;
            mediaInput.MediaId = Guid.NewGuid();

            Randonnee randonnee;
            if (media.NomRandonnee is null || media.NomRandonnee == "")
            {
                mediaInput.Randonnee = null;
            }
            else
            {
                randonnee = await _DbContext.Randonnee.FirstOrDefaultAsync(c => c.Name == media.NomRandonnee);
                mediaInput.Randonnee = randonnee;
            }
           

            _DbContext.Media.Add(mediaInput);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.Select(media => _mapper.Map<MediaDto>(media)).ToListAsync();
        }

        public async Task<List<MediaDto>?> Update(Guid id, MediaDto request)
        { 
            var dbMedia = _DbContext.Media.Find(id);

            if(dbMedia == null)
                return null;

            dbMedia.NomMedia = request.NomMedia;
            dbMedia.CheminDuMedia = request.CheminDuMedia;
            dbMedia.TypeMedia = request.TypeMedia;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.Select(media => _mapper.Map<MediaDto>(media)).ToListAsync();
        }


        public async Task<List<MediaDto>?> DeleteById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result is null)
                return null;

            _DbContext.Pensee.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.Select(media => _mapper.Map<MediaDto>(media)).ToListAsync();
        }



    }
}
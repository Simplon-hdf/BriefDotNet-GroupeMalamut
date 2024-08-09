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
        private readonly IMapper _mapper;
        public MediaService(DataContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }


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

            var dtoResult = _mapper.Map<MediaDto>(mediaResult);

            return dtoResult;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<MediaDto>> Add(MediaDto media)
        {
            var mediaInput = _mapper.Map<Media>(media);
           mediaInput.MediaId = Guid.NewGuid();

            _DbContext.Media.Add(mediaInput);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.Select(media => _mapper.Map<MediaDto>(media)).ToListAsync();
        }

        public async Task<List<MediaDto>?> Update(Guid id, MediaDto request)
        { 
            var dbMedia = _DbContext.Media.Find(id);

            if(dbMedia == null)
                return null;

            dbMedia = _mapper.Map<Media>(request);
            _DbContext.Media.Update(dbMedia);

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
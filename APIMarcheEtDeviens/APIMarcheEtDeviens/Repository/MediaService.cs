using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIMarcheEtDeviens.Repository
{
    public class MediaService : IController<Guid, Media>

    {
        private readonly DataContext _DbContext;
        public MediaService(DataContext context)
        {
            _DbContext = context;
        }

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<Media>?> GetAll()
        {
            var medias = await _DbContext.Media.ToListAsync();
            return medias;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<Media?> GetById(Guid id)
        {
            var result = _DbContext.Media.Find(id);
            if (result == null)
                return null;


            return result;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<Media>> Add(Media media)
        {
            _DbContext.Media.Add(media);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.ToListAsync();
        }

        public async Task<List<Media>?> Update(Guid id, Media request)
        { 
            var dbPensee = _DbContext.Pensee.Find(id);

            if(dbPensee == null)
                return null;

            dbPensee.NomDeLaPensee = request.NomMedia;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.ToListAsync();
        }


        public async Task<List<Media>?> DeleteById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result is null)
                return null;

            _DbContext.Pensee.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Media.ToListAsync();
        }



    }
}
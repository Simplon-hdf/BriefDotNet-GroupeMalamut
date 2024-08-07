using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIMarcheEtDeviens.Repository
{
    public class ParticiperService : IController<int, Participer>

    {
        private readonly DataContext _DbContext;
        private IController<int, Participer> _controllerImplementation;

        public ParticiperService(DataContext context)
        {
            _DbContext = context;
        }

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<Participer>?> GetAll()
        {
            var medias = await _DbContext.Participer.ToListAsync();
            return medias;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<Participer?> GetById(int id)
        {
            var result = _DbContext.Participer.Find(id);
            if (result == null)
                return null;


            return result;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<Participer?>> Add(Participer participer)
        {
            _DbContext.Participer.Add(participer);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.ToListAsync();
        }

        public async Task<List<Participer>?> Update(int id, Participer request)
        { 
            var dbParticiper = _DbContext.Participer.Find(id);

            if(dbParticiper == null)
                return null;

            dbParticiper.ParticiperId = request.ParticiperId;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.ToListAsync();
        }


        public async Task<List<Participer>?> DeleteById(int id)
        {
            var result = _DbContext.Participer.Find(id);
            if (result is null)
                return null;

            _DbContext.Participer.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.ToListAsync();
        }



    }
}
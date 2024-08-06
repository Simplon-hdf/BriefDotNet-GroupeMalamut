using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIMarcheEtDeviens.Repository

{
    public class RandonneurService : IController(Guid ,Randonneur)
    {

        private readonly DataContext _DbContext;
        public RandonneurService(DataContext context)
        {
            _DbContext = context;
        }

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<Randonneur>?> GetAll()
        {
            var randonneurs = await _DbContext.Randonneur.ToListAsync();
            return randonneurs;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<Randonneur?> GetById(int id)
        {
            var result = _DbContext.Randonneur.Find(id);
            if (result == null)
                return null;


            return result;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<Randonneur>> Add(Randonneur randonneur)
        {
            _DbContext.Randonneur.Add(randonneur);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.ToListAsync();
        }

        public async Task<List<Randonneur>?> Update(Guid id, Randonneur request)
        {
            var dbRandonneur = _DbContext.Randonneur.Find();

            if (dbRandonneur == null)
                return null;

            dbRandonneur.Nom = request.Nom;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.ToListAsync();
        }


        public async Task<List<Randonneur>?> DeleteById(Guid id)
        {
            var result = _DbContext.Randonneur.Find(id);
            if (result is null)
                return null;

            _DbContext.Randonneur.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.ToListAsync();
        }

    }
}

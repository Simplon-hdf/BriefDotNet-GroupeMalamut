using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIMarcheEtDeviens.Repository
{
    public class PenseeService : IController<Guid, Pensee>

    {
        private readonly DataContext _DbContext;
        public PenseeService(DataContext context)
        {
            _DbContext = context;
        }

        //Fonction qui récupère et affiche une liste des pensées  
         public async Task<List<Pensee>?> GetAll()
        {
            var pensees = await _DbContext.Pensee.ToListAsync();
            return pensees;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<Pensee?> GetById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result == null)
                return null;


            return result;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<Pensee>> Add(Pensee pensee)
        {
            _DbContext.Pensee.Add(pensee);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.ToListAsync();
        }

        public async Task<List<Pensee>?> Update(Guid id, Pensee request)
        { 
            var dbPensee = _DbContext.Pensee.Find(id);

                if(dbPensee == null)
                return null;

            dbPensee.NomDeLaPensee = request.NomDeLaPensee;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.ToListAsync();
        }


        public async Task<List<Pensee>?> DeleteById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result is null)
                return null;

            _DbContext.Pensee.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.ToListAsync();
        }



    }
}

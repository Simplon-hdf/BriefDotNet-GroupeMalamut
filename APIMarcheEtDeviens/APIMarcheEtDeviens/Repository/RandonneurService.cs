using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace APIMarcheEtDeviens.Repository

{
    public class RandonneurService : IController<Guid , RandonneurDTO>
    {

        private readonly DataContext _DbContext;
        private readonly IMapper _mapper;
        public RandonneurService(DataContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<RandonneurDTO>?> GetAll()
        {
            var randonneurs = await _DbContext.Randonneur.Select(media => _mapper.Map<RandonneurDTO>(media)).ToListAsync();
            return randonneurs;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<RandonneurDTO?> GetById(Guid id)
        {
            var result = _DbContext.Randonneur.Find(id);
            if (result == null)
                return null;
            var resultDTO = _mapper.Map<RandonneurDTO>(result);

            return resultDTO;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<RandonneurDTO>> Add(RandonneurDTO randonneur)
        {
			var randInput = _mapper.Map<Randonneur>(randonneur);
			randInput.RandonneurId = Guid.NewGuid();

			_DbContext.Randonneur.Add(randInput);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.Select(media => _mapper.Map<RandonneurDTO>(media)).ToListAsync();
        }

        public async Task<List<RandonneurDTO>?> Update(Guid id, RandonneurDTO request)
        {
            var dbRandonneur = _DbContext.Randonneur.Find(id);

            if (dbRandonneur == null)
                return null;

            dbRandonneur.Nom = request.Nom;
            dbRandonneur.Prenom = request.Prenom;

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.Select(media => _mapper.Map<RandonneurDTO>(media)).ToListAsync();
        }


        public async Task<List<RandonneurDTO>?> DeleteById(Guid id)
        {
            var result = _DbContext.Randonneur.Find(id);
            if (result is null)
                return null;

            _DbContext.Randonneur.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Randonneur.Select(media => _mapper.Map<RandonneurDTO>(media)).ToListAsync();
        }

    }
}

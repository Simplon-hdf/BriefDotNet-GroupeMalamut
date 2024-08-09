using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;


namespace APIMarcheEtDeviens.Repository
{
    public class PenseeService : IController<Guid, PenseeDto>

    {
        private readonly DataContext _DbContext;
        private readonly IMapper _mapper;
        //mapper permet de réattribuer les attributs d'un objet vers un autre
        //le mappage est defini dans le fichier automapper attribué
        public PenseeService(DataContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }

        //Fonction qui récupère et affiche une liste des pensées  
         public async Task<List<PenseeDto>?> GetAll()
        {
            var pensees = await _DbContext.Pensee.Select(pensee => _mapper.Map<PenseeDto>(pensee)).ToListAsync();
            return pensees;
        }


        //fonction pour recuperer un seul element depuis l'id
        public async Task<PenseeDto?> GetById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result == null)
                return null;
            var dtoResult = _mapper.Map<PenseeDto>(result);


			return dtoResult;

        }

        //fonction pour creer un nouvel element 
        public async Task<List<PenseeDto>> Add(PenseeDto pensee)
		{
            var penseeInput = _mapper.Map<Pensee>(pensee);
            penseeInput.PenseeId = Guid.NewGuid();

			_DbContext.Pensee.Add(penseeInput);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.Select(pensee => _mapper.Map<PenseeDto>(pensee)).ToListAsync();
        }

        public async Task<List<PenseeDto>?> Update(Guid id, PenseeDto request)
        { 
            var dbPensee = _DbContext.Pensee.Find(id);

                if(dbPensee == null)
                return null;

            dbPensee = _mapper.Map<Pensee>(request);
            _DbContext.Pensee.Update(dbPensee);

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.Select(pensee => _mapper.Map<PenseeDto>(pensee)).ToListAsync();
        }


        public async Task<List<PenseeDto>?> DeleteById(Guid id)
        {
            var result = _DbContext.Pensee.Find(id);
            if (result is null)
                return null;

            _DbContext.Pensee.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Pensee.Select(pensee => _mapper.Map<PenseeDto>(pensee)).ToListAsync();
        }



    }
}

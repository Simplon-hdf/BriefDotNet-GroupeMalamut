using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using AutoMapper;
using APIMarcheEtDeviens.Services;


namespace APIMarcheEtDeviens.Repository
{
    public class ParticipantService : IController<Guid, ParticipantDTO>

    {
        private readonly DataContext _DbContext;
        private IController<int, Participant> _controllerImplementation;
        private readonly IMapper _mapper;

        public ParticipantService(DataContext context, IMapper mapper)
        {
            _DbContext = context;
            _mapper = mapper;
        }

        //Fonction qui récupère et affiche une liste des pensées  
        public async Task<List<ParticipantDTO>?> GetAll()
        {
			var medias = _DbContext.Participer.Select(media => _mapper.Map<ParticipantDTO>(media)).ToList();
			return medias;
		}


        //fonction pour recuperer un seul element depuis l'id
        public async Task<ParticipantDTO?> GetById(Guid id)
        {
            var result = _DbContext.Participer.Find(id);
            if (result == null)
                return null;


            return _mapper.Map<ParticipantDTO>(result);

        }

		//fonction pour creer un nouvel element 
		public async Task<List<ParticipantDTO?>> Add(ParticipantDTO participer)
        {
			var participerInput = _mapper.Map<Participant>(participer);

			_DbContext.Participer.Add(participerInput);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.Select(media => _mapper.Map<ParticipantDTO>(media)).ToListAsync();
        }

        public async Task<List<ParticipantDTO>?> Update(Guid id, ParticipantDTO request)
        { 
            var dbParticiper = _DbContext.Participer.Find(id);

            if(dbParticiper == null)
                return null;

            dbParticiper = _mapper.Map<Participant>(request);
            dbParticiper.ParticiperId = id;
            _DbContext.Participer.Update(dbParticiper);

            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.Select(media => _mapper.Map<ParticipantDTO>(media)).ToListAsync();
        }


        public async Task<List<ParticipantDTO>?> DeleteById(Guid id)
        {
            var result = _DbContext.Participer.Find(id);
            if (result is null)
                return null;

            _DbContext.Participer.Remove(result);
            await _DbContext.SaveChangesAsync();

            return await _DbContext.Participer.Select(media => _mapper.Map<ParticipantDTO>(media)).ToListAsync();
        }



    }
}
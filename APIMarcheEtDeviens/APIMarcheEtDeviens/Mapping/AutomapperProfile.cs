using AutoMapper;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;

namespace APIMarcheEtDeviens.Mapping
{
    // Classe de profil AutoMapper pour configurer les mappages entre les modèles et les DTOs
    public class AutomapperProfile : Profile
    {
        // Constructeur où les mappages sont définis
        public AutomapperProfile()
        {
            // Mappage entre le modèle Media et le DTO MediaDto
            CreateMap<Media, MediaDto>()
                // Spécifie que la propriété IdRandonnee du DTO doit être mappée à partir de Randonnee.RandonneeId du modèle source
                .ForMember(dest => dest.IdRandonnee, opt => opt.MapFrom(src => src.Randonnee.RandonneeId))
                // Permet le mappage dans les deux sens (de Media à MediaDto et vice versa)
                .ReverseMap();

            // Mappage entre le modèle Pensee et le DTO PenseeDto
            CreateMap<Pensee, PenseeDto>()
                // Spécifie que la propriété MediaId du DTO doit être mappée à partir de Media.MediaId du modèle source
                .ForMember(dest => dest.MediaId, opt => opt.MapFrom(src => src.Media.MediaId))
                // Permet le mappage dans les deux sens (de Pensee à PenseeDto et vice versa)
                .ReverseMap();

            // Mappage entre le modèle Randonnee et le DTO RandonneeDto
            CreateMap<Randonnee, RandonneeDto>()
                // Permet le mappage dans les deux sens (de Randonnee à RandonneeDto et vice versa)
                .ReverseMap();

            // Mappage entre le modèle Randonneur et le DTO RandonneurDTO
            CreateMap<Randonneur, RandonneurDTO>()
                // Permet le mappage dans les deux sens (de Randonneur à RandonneurDTO et vice versa)
                .ReverseMap();

            // Mappage entre le DTO RoleDto et le modèle Role
            CreateMap<RoleDto, Role>()
                // Permet le mappage dans les deux sens (de RoleDto à Role et vice versa)
                .ReverseMap();

            // Mappage entre le modèle Participant et le DTO ParticipantDTO
            CreateMap<Participant, ParticipantDTO>()
                // Permet le mappage dans les deux sens (de Participant à ParticipantDTO et vice versa)
                .ReverseMap();
        }
    }
}
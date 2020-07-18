using AutoMapper;
using DesafioBoltons.Domain.DTOs;
using DesafioBoltons.Domain.Entities;

namespace DesafioBoltons.Service.Profiles
{
    public class NFeMappingProfile : Profile
    {
        public NFeMappingProfile()
        {
            CreateMap<NFeEntity, NFeDTO>();
            CreateMap<NFeDTO, NFeEntity>();
        }
    }
}

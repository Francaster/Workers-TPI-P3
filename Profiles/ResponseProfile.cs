using AutoMapper;
using ConsultaTrabajadores.API.Models.Responses;

namespace ConsultaTrabajadores.API.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<ResponseForCreationDto, Entities.Response>();
            CreateMap<Entities.Response, ResponseDto>();
        }
    }
}

using AutoMapper;
using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.API.Models.Consulta;
using ConsultaTrabajadores.API.Models.Question;

namespace ConsultaTrabajadores.API.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionForCreationDto, Question>();
            CreateMap<Question, QuestionDto>();
        }
    }
}

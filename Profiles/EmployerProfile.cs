using AutoMapper;
using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.Presentacion.Models;

namespace ConsultaTrabajadores.API.Profiles
{
    public class EmployerProfile : Profile
    {
        public EmployerProfile()
        {
            CreateMap<Employer, EmployerDto>();
        }
    }
}

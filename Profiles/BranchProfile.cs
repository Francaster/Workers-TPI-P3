using AutoMapper;
using ConsultaTrabajadores.Presentacion.Models;

namespace ConsultaTrabajadores.API.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Entities.Branch, BranchDto>();
        }
    }
}

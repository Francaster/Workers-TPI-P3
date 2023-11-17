using ConsultaAlumnos.API.Entities;

namespace ConsultaAlumnos.API.Data
{
    public interface IEmployerRepository
    {
        Employer? GetEmployerById(int userId);
    }
}
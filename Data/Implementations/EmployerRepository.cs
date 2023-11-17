using ConsultaTrabajadores.API.Entities;
using InformacionCiudades.API.DBContexts;

namespace ConsultaTrabajadores.API.Data
{
    public class EmployerRepository : Repository, IEmployerRepository
    {
        public EmployerRepository(WorkersQuestionsContext context) : base(context)
        {

        }

        public Employer? GetEmployerById(int userId) => _context.Employers.Find(userId);
    }
}

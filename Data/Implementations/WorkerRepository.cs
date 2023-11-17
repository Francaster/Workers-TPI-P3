using ConsultaTrabajadores.API.Entities;
using InformacionCiudades.API.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultaTrabajadores.API.Data
{
    public class WorkerRepository : Repository, IWorkerRepository
    {
        public WorkerRepository(WorkersQuestionsContext context) : base(context)
        {
        }

        public ICollection<Branch> GetWorkerBranches(int workerId) =>
            _context.Workers.Include(a => a.BranchesWorked).ThenInclude(m => m.Professors).Where(a => a.Id == workerId)
            .Select(a => a.BranchesWorked).FirstOrDefault() ?? new List<Branch>();

        public Worker? GetWorkerById(int userId) => _context.Workers.Find(userId);
    }
}

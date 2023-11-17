using ConsultaTrabajadores.API.Entities;

namespace ConsultaTrabajadores.API.Data
{
    public interface IWorkerRepository
    {
        Worker? GetWorkerById(int userId);
        ICollection<Subject> GetWorkerSubjects(int workerId);
    }
}
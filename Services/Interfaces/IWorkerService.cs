using ConsultaTrabajadores.Presentacion.Models;

namespace ConsultaTrabajadores.API.Services.Interfaces
{
    public interface IWorkerService
    {
        ICollection<SalaryDto> GetSalaryByWorker(int workerId);
    }
}
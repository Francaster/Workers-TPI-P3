// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using ConsultaTrabajadores.API.Services.Interfaces;
using ConsultaTrabajadores.Presentacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaTrabajadores.API.Controllers
{
    [Route("api/worker")]
    [ApiController]
    [Authorize]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            this._workerService = workerService;
        }
        [HttpGet("salary")]
        public ActionResult<ICollection<SalaryDto>> GetSalario()
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "trabajador")
                return Forbid();

            return _workerService.GetSalaryByWorker(int.Parse(user)).ToList();
        }
    }
}

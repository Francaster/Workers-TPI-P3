using ConsultaTrabajadores.API.Models.Question;
using ConsultaTrabajadores.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultaTrabajadores.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/employer")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            this._employerService = employerService;
        }

        [HttpGet("pendingquestions")]
        public ActionResult<ICollection<QuestionDto>> GetPendingQuestions(bool withResponses = false)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "empleador")
                return Forbid();

            return _employerService.GetPendingQuestions(int.Parse(user), withResponses).ToList();

        }
    }
}

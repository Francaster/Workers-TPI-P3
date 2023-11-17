using ConsultaTrabajadores.API.Models.Question;

namespace ConsultaTrabajadores.API.Services.Interfaces
{
    public interface IProfessorService
    {
        ICollection<QuestionDto> GetPendingQuestions(int userId, bool withResponses);
    }
}

using ConsultaTrabajadores.API.Models.Consulta;
using ConsultaTrabajadores.API.Models.Question;
using ConsultaTrabajadores.Presentacion.Enums;

namespace ConsultaTrabajadores.API.Services.Interfaces
{
    public interface IQuestionService
    {
        QuestionDto CreateQuestion(QuestionForCreationDto newQuestion, int userId);
        QuestionDto GetQuestion(int questionId);
        bool IsQuestionIdValid(int questionId);
        void ChangeQuestionStatus(int questionId, QuestionState status);
        void ChangeQuestionStatus(int questionId);
    }
}
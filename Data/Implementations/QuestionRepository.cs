using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.Presentacion.Enums;
using InformacionCiudades.API.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultaTrabajadores.API.Data
{
    public class QuestionRepository : Repository, IQuestionRepository
    {
        public QuestionRepository(WorkersQuestionsContext context) : base(context)
        {
        }

        public void AddQuestion(Question newQuestion)
        {
            _context.Questions.Add(newQuestion);
        }

        public Question? GetQuestion(int questionId)
        {
            return _context.Questions
                .Include(q => q.AssignedEmployer)
                .Include(q => q.Student)
                .FirstOrDefault(c => c.Id == questionId);
        }

        public bool IsQuestionIdValid(int questionId)
        {
            return _context.Questions.Any(q => q.Id == questionId);
        }

        public IOrderedQueryable<Question> GetPendingQuestions(int userId, bool withResponses)
        {
            if (withResponses)
                return _context.Questions
                    .Include(q => q.Responses).ThenInclude(r => r.Creator)
                    .Where(q => q.EmployerId == userId && q.QuestionState == QuestionState.WaitingEmployerAnwser)
                    .OrderBy(q => q.LastModificationDate);
            return _context.Questions
                .Where(q => q.EmployerId == userId && q.QuestionState == QuestionState.WaitingEmployerAnwser)
                .OrderBy(q => q.LastModificationDate);
        }
    }
}

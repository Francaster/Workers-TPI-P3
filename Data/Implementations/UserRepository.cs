using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.API.Models;
using ConsultaTrabajadores.API.DBContexts;

namespace ConsultaTrabajadores.API.Data
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(WorkersQuestionsContext context) : base(context)
        {
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (authRequestBody.UserType == "trabajador")
                return _context.Workers.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
            return _context.Students.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}

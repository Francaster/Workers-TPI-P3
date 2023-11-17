using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.API.Models;

namespace ConsultaTrabajadores.API.Data
{
    public interface IUserRepository : IRepository
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        User? GetUserById(int userId);
    }
}
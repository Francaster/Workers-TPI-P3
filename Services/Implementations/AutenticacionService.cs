using ConsultaTrabajadores.API.Data;
using ConsultaTrabajadores.API.Entities;
using ConsultaTrabajadores.API.Models;
using ConsultaTrabajadores.API.Services.Interfaces;

namespace ConsultaTrabajadores.API.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AutenticacionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Worker? ValidateWorker(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateWorker(authenticationRequest);
        }
    }
}

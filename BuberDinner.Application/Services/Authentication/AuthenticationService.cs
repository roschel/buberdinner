using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            // create user (generate unique Id) and persist it
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);


            return new AuthenticationResult(
                user.Id,
                token,
                firstName,
                lastName,
                email);
        }

        public AuthenticationResult Login(string email, string password)
        {
            // validate the user exists.
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with the given email does not exist");
            }
            // validate the password is correct.
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResult(
                user.Id,
                token,
                user.FirstName,
                user.LastName,
                user.Email);
        }
    }
}
using WebLesson.Business.Contracts;
using WebLesson.Business.Helpers;
using WebLesson.Business.Responses;
using WebLesson.Data.Contracts;
using WebLesson.Data.Entities;

namespace WebLesson.Business.Services
{
    public class UserService(
        IRepository<User> userRepository, 
        IPasswordHasher passwordHasher, 
        ITokenProvider tokenProvider
    ) : IUserService
    {
        public async Task<BaseResponse<string>> Login(Requests.LoginRequest request)
        {
            var user = await userRepository.FindSingle(x => x.Username == request.Username);

            if (user is null)
            {
                return BaseResponse<string>.Unauthorized();
            }

            bool passwordsAreEqual = passwordHasher.Verify(request.Password, user.PasswordHash);

            if (!passwordsAreEqual)
            {
                return BaseResponse<string>.Unauthorized();
            }

            var token = tokenProvider.CreateToken(user);

            return BaseResponse<string>.Successful(token);
        }

        public async Task<BaseResponse<string>> Register(Requests.RegisterRequest request)
        {
            var user = await userRepository.FindSingle(x => x.Username == request.Username);

            if (user is not null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.Conflict,
                    Message = "User with this username already exists"
                };
            }

            string passwordHash = passwordHasher.Hash(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash
            };

            await userRepository.Add(newUser);
            await userRepository.SaveChanges();

            var token = tokenProvider.CreateToken(newUser);

            return BaseResponse<string>.Successful(token);
        }
    }
}

using Azure.Core;
using WebLesson.Business.Responses;

namespace WebLesson.Business.Contracts
{
    public interface IUserService
    {
        Task<BaseResponse<string>> Register(Requests.RegisterRequest request);
        Task<BaseResponse<string>> Login(Requests.LoginRequest request);
    }
}

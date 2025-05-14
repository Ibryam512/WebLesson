using WebLesson.Data.Entities;

namespace WebLesson.Business.Contracts
{
    public interface ITokenProvider
    {
        string CreateToken(User user);
    }
}

using GoldenSolution.Core.DTO.Authentication;

namespace GoldenSolution.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string userId);
    }
}

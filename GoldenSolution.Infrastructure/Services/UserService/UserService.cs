using GoldenSolution.Core.DTO.Authentication;

namespace GoldenSolution.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task<UserDto> GetUser(string userId)
        {
			var user = new UserDto
			{
				UserId = userId,
				Name = "Derek"
			};

            //var user = await IRepository.GetUser();

            return user;
		}
    }
}

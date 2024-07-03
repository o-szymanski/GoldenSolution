using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.DAL.Models;

namespace GoldenSolution.Core.Mappers.AuthenticationMappers;

public static class UserMap
{
	public static UserDto ToUserDto(User user) => new(user.Id, user.FirstName);
}

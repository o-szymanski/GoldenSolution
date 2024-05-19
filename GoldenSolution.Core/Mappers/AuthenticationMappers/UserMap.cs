using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.DAL.Models;

namespace GoldenSolution.Core.Mappers.AuthenticationMappers;

public static class UserMap
{
	public static UserDto ToUserDto(User user)
	{
		return new UserDto
		{
			Id = user.Id,
			FirstName = user.FirstName
		};
	}
}

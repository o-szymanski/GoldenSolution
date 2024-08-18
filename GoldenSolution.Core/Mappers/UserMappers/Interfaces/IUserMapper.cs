using GoldenSolution.Core.DTO.User;
using GoldenSolution.DAL.Models;

namespace GoldenSolution.Core.Mappers.UserMappers;

public interface IUserMapper
{
	public UserDto Map(ApplicationUser applicationUser);
}

using GoldenSolution.Core.DTO.User;
using GoldenSolution.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.UserMappers;

[Mapper]
public partial class UserMapper
{
	public partial UserDto Map(User user);
}

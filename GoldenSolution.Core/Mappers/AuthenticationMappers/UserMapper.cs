using GoldenSolution.Core.DTO.Authentication;
using GoldenSolution.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.AuthenticationMappers;

[Mapper]
public partial class UserMapper
{
	public partial UserDto Map(User user);
}

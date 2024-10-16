﻿using GoldenSolution.Core.Mappers.UserMappers.Interfaces;
using GoldenSolution.Core.Models.DTO.User;
using GoldenSolution.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace GoldenSolution.Core.Mappers.UserMappers;

[Mapper]
public partial class UserMapper : IUserMapper
{
	public partial UserDto Map(ApplicationUser applicationUser);
}

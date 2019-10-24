using MyAwesomeProject.Dto;
using System.Collections.Generic;

namespace MyAwesomeProject.Services
{
	public interface IUserService
	{
		UserDto Authenticate(string username, string password);
		IEnumerable<UserDto> GetAll();
		UserDto GetById(int id);
		UserDto Create(RegisterDto dto);
		void Update(UserDto dto, string password = null);
		void UpdateRoles(int id, List<RoleDto> roles);
		void Delete(int id);
	}
}

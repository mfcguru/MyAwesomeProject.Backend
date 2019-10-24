using MyAwesomeProject.Dto;
using System.Collections.Generic;

namespace MyAwesomeProject.Services
{
	public interface IRoleService
	{
		IEnumerable<RoleDto> GetAll();
		RoleDto GetById(int id);
		object Create(RoleDto dto);
		void Update(int id, RoleDto dto);
		void Delete(int id);
	}
}

using MyAwesomeProject.Dto;
using System.Collections.Generic;

namespace MyAwesomeProject.Services
{
	public interface IAuthorService
	{
		AuthorQueryDto GetById(int id);
		IEnumerable<AuthorQueryDto> GetAll();
		object Create(AuthorDto dto);
		void Update(int id, AuthorDto dto);
		void Delete(int id);
	}
}

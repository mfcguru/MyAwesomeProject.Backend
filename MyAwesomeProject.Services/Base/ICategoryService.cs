using MyAwesomeProject.Dto;
using System.Collections.Generic;

namespace MyAwesomeProject.Services
{
	public interface ICategoryService
	{
		CategoryQueryDto GetById(int id);
		IEnumerable<CategoryQueryDto> GetAll();
		object Create(CategoryDto dto);
		void Update(int id, CategoryDto dto);
		void Delete(int id);
	}
}

using MyAwesomeProject.Dto;
using System.Collections.Generic;

namespace MyAwesomeProject.Services
{
	public interface IBookService
	{
		BookQueryDto GetById(int id);
		IEnumerable<BookQueryDto> GetAll();
		object Create(BookDto dto);
		void Update(int id, BookDto dto);
		void Delete(int id);
	}
}

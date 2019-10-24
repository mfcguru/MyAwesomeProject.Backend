using AutoMapper;
using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Data;
using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Dto;
using System.Collections.Generic;
using System.Linq;

namespace MyAwesomeProject.Services
{
	public class BookService : IBookService
	{
		private DataContext context;

		public BookService(DataContext db)
		{
			this.context = db;
		}

		public IEnumerable<BookQueryDto> GetAll()
		{
			return Mapper.Map<IEnumerable<BookQueryDto>>(context.Books);
		}

		public BookQueryDto GetById(int id)
		{
			var entity = context.Books.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return Mapper.Map<BookQueryDto>(entity);
		}

		public object Create(BookDto dto)
		{
			var entity = Mapper.Map<Book>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.BookId;
		}

		public void Update(int id, BookDto dto)
		{
			var entity = context.Books.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(Mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Books.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}

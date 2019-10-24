using AutoMapper;
using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Data;
using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Dto;
using System.Collections.Generic;
using System.Linq;

namespace MyAwesomeProject.Services
{
	public class AuthorService : IAuthorService
	{
		private DataContext context;

		public AuthorService(DataContext db)
		{
			this.context = db;
		}

		public IEnumerable<AuthorQueryDto> GetAll()
		{
			return Mapper.Map<IEnumerable<AuthorQueryDto>>(context.Authors);
		}

		public AuthorQueryDto GetById(int id)
		{
			var entity = context.Authors.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return Mapper.Map<AuthorQueryDto>(entity);
		}

		public object Create(AuthorDto dto)
		{
			var entity = Mapper.Map<Author>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.AuthorId;
		}

		public void Update(int id, AuthorDto dto)
		{
			var entity = context.Authors.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(Mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Authors.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}

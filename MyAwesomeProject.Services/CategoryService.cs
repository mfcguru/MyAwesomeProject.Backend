using AutoMapper;
using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Data;
using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Dto;
using System.Collections.Generic;
using System.Linq;

namespace MyAwesomeProject.Services
{
	public class CategoryService : ICategoryService
	{
		private DataContext context;

		public CategoryService(DataContext db)
		{
			this.context = db;
		}

		public IEnumerable<CategoryQueryDto> GetAll()
		{
			return Mapper.Map<IEnumerable<CategoryQueryDto>>(context.Categories);
		}

		public CategoryQueryDto GetById(int id)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return Mapper.Map<CategoryQueryDto>(entity);
		}

		public object Create(CategoryDto dto)
		{
			var entity = Mapper.Map<Category>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.CategoryId;
		}

		public void Update(int id, CategoryDto dto)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(Mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}

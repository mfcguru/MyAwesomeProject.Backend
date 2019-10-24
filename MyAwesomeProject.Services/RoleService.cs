using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Data;
using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Dto;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace MyAwesomeProject.Services
{
	public class RoleService : IRoleService
	{
		private DataContext context;

		public RoleService(DataContext context)
		{
			this.context = context;
		}

		public object Create(RoleDto dto)
		{
			var entity = Mapper.Map<Role>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.RoleId; ;
		}

		public void Delete(int id)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}

		public IEnumerable<RoleDto> GetAll()
		{
			return Mapper.Map<IEnumerable<RoleDto>>(context.Roles);
		}

		public RoleDto GetById(int id)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return Mapper.Map<RoleDto>(entity);
		}

		public void Update(int id, RoleDto dto)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			entity.RoleName = dto.RoleName;

			context.Update(entity);
			context.SaveChanges();
		}
	}
}

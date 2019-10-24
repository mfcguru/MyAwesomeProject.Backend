using AutoMapper;
using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Dto;
using System.Linq;

namespace MyAwesomeProject.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Role, RoleDto>();
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Id, src => src.MapFrom(o => o.UserId))
				.ForMember(dest => dest.Roles, src => src.MapFrom(o => o.UserInRoles.Select(s => s.Role)));

			CreateMap<RoleDto, Role>();
			CreateMap<UserDto, User>()
				.ForMember(dest => dest.UserId, src => src.MapFrom(o => o.Id));
			CreateMap<RegisterDto, User>();

			CreateMap<AuthorDto, Author>();
			CreateMap<BookDto, Book>();
			CreateMap<BookAuthorDto, BookAuthor>();
			CreateMap<CategoryDto, Category>();
			CreateMap<Author, AuthorDto>();
			CreateMap<Book, BookDto>();
			CreateMap<Category, CategoryDto>();
			CreateMap<Author, AuthorQueryDto>();
			CreateMap<Book, BookQueryDto>();
			CreateMap<Category, CategoryQueryDto>();

			CreateMap<BookAuthor, BookAuthorDto>()
				.ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.BookName));
		}
	}
}

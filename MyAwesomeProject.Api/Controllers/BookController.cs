using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Dto;
using MyAwesomeProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyAwesomeProject.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private IBookService BookService;		

		public BookController(IBookService BookService)
		{
			this.BookService = BookService;			
		}

		[HttpGet]
		public ActionResult<IEnumerable<BookQueryDto>> Get()
		{
			return Ok(BookService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<BookQueryDto> Get(int id)
		{
			return Ok(BookService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] BookDto dto)
		{
			return Ok(new { id = BookService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] BookDto dto)
		{
			BookService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			BookService.Delete(id);
			return Ok();
		}
	}
}

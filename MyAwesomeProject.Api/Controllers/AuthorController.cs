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
	public class AuthorController : ControllerBase
	{
		private IAuthorService AuthorService;		

		public AuthorController(IAuthorService AuthorService)
		{
			this.AuthorService = AuthorService;			
		}

		[HttpGet]
		public ActionResult<IEnumerable<AuthorQueryDto>> Get()
		{
			return Ok(AuthorService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<AuthorQueryDto> Get(int id)
		{
			return Ok(AuthorService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] AuthorDto dto)
		{
			return Ok(new { id = AuthorService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] AuthorDto dto)
		{
			AuthorService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			AuthorService.Delete(id);
			return Ok();
		}
	}
}

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
	public class CategoryController : ControllerBase
	{
		private ICategoryService CategoryService;		

		public CategoryController(ICategoryService CategoryService)
		{
			this.CategoryService = CategoryService;			
		}

		[HttpGet]
		public ActionResult<IEnumerable<CategoryQueryDto>> Get()
		{
			return Ok(CategoryService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<CategoryQueryDto> Get(int id)
		{
			return Ok(CategoryService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] CategoryDto dto)
		{
			return Ok(new { id = CategoryService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] CategoryDto dto)
		{
			CategoryService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			CategoryService.Delete(id);
			return Ok();
		}
	}
}

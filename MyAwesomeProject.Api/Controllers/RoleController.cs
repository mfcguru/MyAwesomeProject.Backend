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
	public class RoleController : ControllerBase
	{
		private IRoleService RoleService;

		public RoleController(IRoleService RoleService)
		{
			this.RoleService = RoleService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<RoleDto>> Get()
		{
			return Ok(RoleService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<RoleDto> Get(int id)
		{
			return Ok(RoleService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] RoleDto dto)
		{
			return Ok(new { id = RoleService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] RoleDto dto)
		{
			RoleService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			RoleService.Delete(id);
			return Ok();
		}
	}
}

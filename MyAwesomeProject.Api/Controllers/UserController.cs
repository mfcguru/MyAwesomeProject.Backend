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
	public class UserController : ControllerBase
	{
		private IUserService UserService;

		public UserController(IUserService UserService)
		{
			this.UserService = UserService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<UserDto>> Get()
		{
			return Ok(UserService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<UserDto> Get(int id)
		{
			return Ok(UserService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] RegisterDto dto)
		{
			return Ok(new { id = UserService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UserDto dto)
		{
			dto.Id = id;
			UserService.Update(dto);
			return Ok();
		}

		[HttpPut("{id}/roles")]
		public IActionResult Put(int id, [FromBody] List<RoleDto> dto)
		{
			UserService.UpdateRoles(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			UserService.Delete(id);
			return Ok();
		}
	}
}

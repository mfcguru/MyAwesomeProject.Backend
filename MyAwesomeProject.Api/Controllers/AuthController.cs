using MyAwesomeProject.Api.Helpers;
using MyAwesomeProject.BusinessRules;
using MyAwesomeProject.Dto;
using MyAwesomeProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyAwesomeProject.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private IUserService userService;		
		private readonly AppSettings appSettings;

		public AuthController(
			IUserService userService,			
			IOptions<AppSettings> appSettings)
		{
			this.userService = userService;			
			this.appSettings = appSettings.Value;
		}

		/// <summary>
		/// Authenticate user
		/// </summary>
		/// <param name="credentials"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult Authenticate([FromBody]LoginDto credentials)
		{
			var user = userService.Authenticate(credentials.Username, credentials.Password);
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);

			// return basic user info (without password) and token to store client side
			return Ok(new
			{
				Id = user.Id,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Token = tokenString,
				Roles = user.Roles
			});
		}

		/// <summary>
		/// Register a new user 
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]RegisterDto dto)
		{
			userService.Create(dto);
			return Ok();
		}
	}
}

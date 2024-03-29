using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class RegisterDto
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

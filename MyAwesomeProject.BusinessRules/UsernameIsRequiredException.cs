using System.Net;

namespace MyAwesomeProject.BusinessRules
{
	public class UsernameIsRequiredException : BusinessRulesException
	{
		private const string message = "Username is required";

		public UsernameIsRequiredException() : base(HttpStatusCode.BadRequest, message) { }
	}
}

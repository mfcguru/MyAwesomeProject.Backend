using System.Net;

namespace MyAwesomeProject.BusinessRules
{
	public class PasswordIsRequiredException : BusinessRulesException
	{
		private const string message = "Password is required";

		public PasswordIsRequiredException() : base(HttpStatusCode.BadRequest, message) { }
	}
}

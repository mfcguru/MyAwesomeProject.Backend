using System.Net;

namespace MyAwesomeProject.BusinessRules
{
	public class DuplicateConsraintException : BusinessRulesException
	{
		private const string message = "Duplicate constraint";

		public DuplicateConsraintException() : base(HttpStatusCode.BadRequest, message) { }
	}
}

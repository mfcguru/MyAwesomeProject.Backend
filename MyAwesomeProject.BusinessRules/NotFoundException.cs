using System.Net;

namespace MyAwesomeProject.BusinessRules
{
	public class NotFoundException : BusinessRulesException
	{
		private const string message = "Record not found";

		public NotFoundException() : base(HttpStatusCode.NotFound, message) { }
	}
}

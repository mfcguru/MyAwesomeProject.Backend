using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class AuthorQueryDto : AuthorDto
	{
		public int AuthorId { get; set; }
	}
}

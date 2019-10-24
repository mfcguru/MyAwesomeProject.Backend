using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class AuthorDto
	{	
		
		[Required]
		public string AuthorName { get; set; }
		[Required]
		public IEnumerable<BookAuthorDto> BookAuthors { get; set; }
	}
}

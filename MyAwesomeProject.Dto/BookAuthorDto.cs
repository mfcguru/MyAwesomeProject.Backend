using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class BookAuthorDto
	{	
		public int BookId { get; set; }
		public int AuthorId { get; set; }
		public string BookName { get; set; }
	}
}

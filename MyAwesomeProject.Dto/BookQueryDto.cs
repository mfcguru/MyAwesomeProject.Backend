using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class BookQueryDto : BookDto
	{
		public int BookId { get; set; }
	}
}

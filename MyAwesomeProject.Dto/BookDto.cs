using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class BookDto
	{	
		
		[Required]
		public string BookName { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }
		
	}
}

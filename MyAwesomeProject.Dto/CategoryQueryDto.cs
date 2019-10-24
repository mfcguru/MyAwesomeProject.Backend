using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAwesomeProject.Dto
{
	public class CategoryQueryDto : CategoryDto
	{
		public int CategoryId { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAwesomeProject.Data.Entities
{
	public class Book
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookId { get; set; }
		[Required]
		public string BookName { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public virtual ICollection<BookAuthor> BookAuthors { get; set; }
	}
}

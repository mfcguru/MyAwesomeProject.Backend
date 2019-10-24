using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAwesomeProject.Data.Entities
{
	public class BookAuthor
	{
		[Key]
		public int BookId { get; set; }
		public virtual Book Book { get; set; }
		[Key]
		public int AuthorId { get; set; }
		public virtual Author Author { get; set; }
	}
}

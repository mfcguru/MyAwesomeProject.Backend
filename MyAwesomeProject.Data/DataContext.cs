using MyAwesomeProject.Data.Entities;
using MyAwesomeProject.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyAwesomeProject.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BookAuthor> BookAuthors { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		    foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
		    {
		        entityType.Relational().TableName = entityType.DisplayName();
		    }
			modelBuilder.Entity<UserInRole>().HasKey(o => new { o.UserId, o.RoleId });
			modelBuilder.Entity<UserInRole>()
				.HasOne<User>(sc => sc.User)
				.WithMany(s => s.UserInRoles)
				.HasForeignKey(sc => sc.UserId);
			modelBuilder.Entity<UserInRole>()
				.HasOne<Role>(sc => sc.Role)
				.WithMany(s => s.UserInRoles)
				.HasForeignKey(sc => sc.RoleId);

			modelBuilder.Entity<BookAuthor>().HasKey(o => new { o.BookId, o.AuthorId });
			modelBuilder.Entity<BookAuthor>()
				.HasOne<Book>(sc => sc.Book)
				.WithMany(s => s.BookAuthors)
				.HasForeignKey(sc => sc.BookId);
			modelBuilder.Entity<BookAuthor>()
				.HasOne<Author>(sc => sc.Author)
				.WithMany(s => s.BookAuthors)
				.HasForeignKey(sc => sc.AuthorId);
			
			SeedAdminUser(modelBuilder);
		}
		
		private void SeedAdminUser(ModelBuilder modelBuilder)
		{
			var adminRole = new Role { RoleId = 1, RoleName = "admin" };
			modelBuilder.Entity<Role>().HasData(adminRole);

			byte[] passwordHash, passwordSalt;
			AuthHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);
			var adminUser = new User
			{
				UserId = 1,
				Username = "admin",
				FirstName = "Default",
				LastName = "Admin",
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt
			};
			modelBuilder.Entity<User>().HasData(adminUser);

			modelBuilder.Entity<UserInRole>().HasData(new UserInRole
			{
				RoleId = adminRole.RoleId,
				UserId = adminUser.UserId
			});
		}
	}
}

using DraggableApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DraggableApp.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

		}
		public DbSet<Post> posts { get; set; }

		
	}
}

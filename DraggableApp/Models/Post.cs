using System.ComponentModel.DataAnnotations;

namespace DraggableApp.Models
{
	public class Post
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public int RowNo { get; set; }
		public int ColNo { get; set; }

	}
}

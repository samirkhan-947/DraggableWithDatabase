using DraggableApp.Data;
using DraggableApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DraggableApp.Controllers
{
	public class DragController : Controller
	{
		private readonly AppDbContext _db;
		public DragController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var list = _db.posts.ToList();
			var lsit2 = list.OrderBy(x => x.RowNo);
			return View(lsit2.ToList());
		}
		public IActionResult UpdateItem(string itemIds)
		{
			int count = 1;
			List<int> itemListId = new List<int>();
			itemListId = itemIds.Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
			foreach (var itemid in itemListId)
			{
				try
				{
					Post item = _db.posts.AsNoTracking().Where(x=>x.Id== itemid).FirstOrDefault();
					item.RowNo = count;
					_db.posts.AddOrUpdate(item);
					_db.SaveChanges();
				}
				catch (Exception)
				{

					continue;
				}
				count++;
			}
			return Json(true, new Newtonsoft.Json.JsonSerializerSettings());
		}
	}
}

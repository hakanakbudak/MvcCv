using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class HobiController : Controller
    {
		GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

		[HttpGet]
		public IActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

		[HttpPost]
		public IActionResult Index(TblHobilerim p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Aciklama1 = p.Aciklama1;
			t.Aciklama2 = p.Aciklama2;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}

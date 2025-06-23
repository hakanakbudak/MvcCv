using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class YetenekController : Controller
    {
        GenericRepository<TblYetenekler> repo= new GenericRepository<TblYetenekler>();

        public IActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public IActionResult YeniYetenek()
        {
            return View();
        }

		[HttpPost]
		public IActionResult YeniYetenek(TblYetenekler p)
		{
			repo.TAdd(p);
            return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

		[HttpPost]
		public ActionResult YetenekGuncelle(TblYetenekler p)
		{
			TblYetenekler t = repo.Find(x => x.ID == p.ID);
			t.Yetenek = p.Yetenek;
			t.Oran = p.Oran;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}

		public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }


	}
}

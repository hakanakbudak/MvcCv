using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class SosyalMedyaController : Controller
    {
		GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

		public IActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

		[HttpGet]
		public IActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Ekle(TblSosyalMedya p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult SosyalMedyaGuncelle(int id)
		{
			var hesap = repo.Find(x => x.ID == id);
			return View(hesap);
		}

		[HttpPost]
		public IActionResult SosyalMedyaGuncelle(TblSosyalMedya p)
		{
			var hesap = repo.Find(x => x.ID == p.ID);
			hesap.Ad = p.Ad;
			hesap.Link = p.Link;
			repo.TUpdate(hesap);
			return RedirectToAction("Index");
		}


		public ActionResult SosyalMedyaSil(int id)
		{
			var sosyalmedya = repo.Find(x => x.ID == id);

			repo.TDelete(sosyalmedya);

			return RedirectToAction("Index");
		}
	}
}

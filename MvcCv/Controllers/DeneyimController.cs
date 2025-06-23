using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();

        public IActionResult Index()
        {
            var values = repo.List();

            return View(values);
        }

        [HttpGet]
        public IActionResult DeneyimEkle()
        {
            return View();  
        }

		[HttpPost]
		public IActionResult DeneyimEkle(TblDeneyimlerim p)
		{
            repo.TAdd(p);
            return RedirectToAction("Index");
		}

		public IActionResult DeneyimSil(int id)
		{
           TblDeneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult DeneyimGuncelle(int id)
		{
           TblDeneyimlerim t = repo.Find(x => x.ID == id);
			return View(t);
		}

		[HttpPost]
		public IActionResult DeneyimGuncelle(TblDeneyimlerim p)
		{
			TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih  = p.Tarih;
            repo.TUpdate(t);
			return RedirectToAction("Index");
		}

	}
}

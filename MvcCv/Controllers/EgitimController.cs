using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class EgitimController : Controller
    {
		GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

		public IActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public IActionResult EgitimEkle()
        {
            return View();
        }

		[HttpPost]
		public IActionResult EgitimEkle(TblEgitimlerim e)
		{
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }

			repo.TAdd(e);
			return RedirectToAction("Index");
		}

        public IActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult EgitimGuncelle(int id)
        {
			TblEgitimlerim e = repo.Find(x => x.ID == id);
			return View(e);
		}

		[HttpPost]
		public IActionResult EgitimGuncelle(TblEgitimlerim t)
		{

			if (!ModelState.IsValid)
			{
				return View("EgitimGuncelle");
			}

			TblEgitimlerim e = repo.Find(x => x.ID == t.ID);
            e.Baslik = t.Baslik;
            e.AltBaslik1 = t.AltBaslik1;
            e.AltBaslik2 = t.AltBaslik2;
            e.Gno = t.Gno;
            e.Tarih = t.Tarih;
            repo.TUpdate(e);
			return RedirectToAction("Index");
		}


	}
}

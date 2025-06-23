using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class SertifikaController : Controller
    {
		GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();

		public IActionResult Index()
        {
            var sertifika = repo.List();

            return View(sertifika);
        }

        [HttpGet]
        public IActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
		public IActionResult SertifikaGetir(TblSertifikalarım t)
		{
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);

			return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

		[HttpPost]
		public ActionResult SertifikaEkle(TblSertifikalarım p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}

		public ActionResult SertifikaSil(int id)
		{
            var sertifika = repo.Find(x => x.ID == id);

            repo.TDelete(sertifika);

			return RedirectToAction("Index");
		}

	}
}

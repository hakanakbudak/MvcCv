using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class HakkimdaController : Controller
    {
		GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

		[HttpGet]
		public IActionResult Index()
		{
			var hakkimda = repo.List();
			return View(hakkimda);
		}

		[HttpPost]
		public IActionResult Index(TblHakkimda p)
		{
			var t = repo.Find(x => x.ID == 1);
			t.Ad = p.Ad;
			t.Soyad = p.Soyad;
			t.Adres = p.Adres;
			t.Mail = p.Mail;
			t.Telefon = p.Telefon;
			t.Aciklama = p.Aciklama;
			t.Resim = p.Resim;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}



	}
}

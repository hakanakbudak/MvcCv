using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class iletisimController : Controller
    {
		GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();

		public IActionResult Index()
        {
            var mesajlar = repo.List().OrderByDescending(x => x.Tarih).ToList(); 

            return View(mesajlar);
        }
    }
}

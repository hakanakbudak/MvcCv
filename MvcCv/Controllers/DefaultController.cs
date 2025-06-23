using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
		private readonly MvcCvContext _context;

		public DefaultController(MvcCvContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult SendMessage(Tbliletisim model)
		{
			model.Tarih = DateTime.Now;
			_context.Tbliletisim.Add(model);
			_context.SaveChanges();

			return RedirectToAction("Index", "Default");
		}

	}
}

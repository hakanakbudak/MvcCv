using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._NavigationComponentPartial
{
	public class _NavigationComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _NavigationComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblHakkimda.FirstOrDefault();
			ViewBag.profilePhoto = values.Resim;

			return View();
		}
	}
}

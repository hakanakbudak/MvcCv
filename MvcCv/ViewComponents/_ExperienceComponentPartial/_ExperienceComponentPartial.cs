using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._ExperienceComponentPartial
{
	public class _ExperienceComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _ExperienceComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblDeneyimlerim.ToList();

			return View(values);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._InterestsComponentPartial
{
	public class _InterestsComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _InterestsComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblHobilerim.ToList();
			return View(values);
		}
	}
}

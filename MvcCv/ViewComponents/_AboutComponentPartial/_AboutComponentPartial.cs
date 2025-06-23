using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents.LayoutViewComponents
{
	public class _AboutComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _AboutComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblHakkimda.ToList();

			return View(values);
		}

	}
}

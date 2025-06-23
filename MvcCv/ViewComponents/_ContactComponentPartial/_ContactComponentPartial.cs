using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._ContactComponentPartial
{
	public class _ContactComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _ContactComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			//var values = context.Tbliletisim.ToList();
			return View();
		}

	}
}

using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._AwardsComponentPartial
{
	public class _AwardsComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _AwardsComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblSertifikalarım.ToList();

			return View(values);
		}
	}
}

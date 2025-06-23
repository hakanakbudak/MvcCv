using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._SocialMediaComponentsPartial
{
	public class _SocialMediaComponentsPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _SocialMediaComponentsPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblSosyalMedya.ToList();
			return View(values);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._EducationComponentPartial
{
	public class _EducationComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _EducationComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblEgitimlerim.ToList();
			return View(values);
		}
	}
}

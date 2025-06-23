using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents._SkillsComponentPartial
{
	public class _SkillsComponentPartial : ViewComponent
	{
		private readonly MvcCvContext _context;

		public _SkillsComponentPartial(MvcCvContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var values = _context.TblYetenekler.ToList();
			return View(values);
		}
	}
}

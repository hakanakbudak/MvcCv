using Microsoft.AspNetCore.Mvc;

namespace MvcCv.ViewComponents._HeadComponentPartial
{
	public class _HeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

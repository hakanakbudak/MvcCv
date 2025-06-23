using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MvcCv.Controllers
{
	public class LoginController : Controller
	{
		private readonly MvcCvContext _context;

		public LoginController(MvcCvContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LoginUser(string username, string password)
		{
			// Kullanıcıyı doğrulama
			var user = _context.TblAdmin.Where(x => x.KullaniciAdi == username && x.Sifre == password).FirstOrDefault();

			if (user == null)
			{
				ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
				return View("Index");
			}

			// Kullanıcının YetkiDerecesi'ne göre bir rol belirleyelim.
			//string userRole;
			//if (user. > 10)
			//	userRole = "Admin";
			//else if (user.YetkiDerecesi > 5 && user.YetkiDerecesi < 10)
			//	userRole = "SPZ";
			//else
			//	userRole = "User";

			// Kullanıcı doğrulandı, Cookie'ye kimlik bilgilerini kaydedelim
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.KullaniciAdi),
				new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()), // Kimlik
                // Eğer rol tabanlı yetkilendirme istiyorsanız, bunu burada belirtebilirsiniz:
                //new Claim(ClaimTypes.Role, userRole)
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var authProperties = new AuthenticationProperties
			{
				IsPersistent = true // Kullanıcı "Beni hatırla" seçeneğiyle giriş yaparsa, oturum süresinin uzatılmasını sağlar
			};

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

			return RedirectToAction("Index", "Deneyim"); // Giriş başarılı, anasayfaya yönlendir
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Kullanıcıyı çıkış yapma
			return RedirectToAction("Index", "Login"); // Giriş sayfasına yönlendir
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

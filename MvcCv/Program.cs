using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

var builder = WebApplication.CreateBuilder(args);


// Connection string'i al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i DI sistemine ekle
builder.Services.AddDbContext<MvcCvContext>(options =>
	options.UseSqlServer(connectionString));

//------------------------------------------------------------------------


// Authentication yapýlandýrmasý - Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Kullanýcý giriþi yapýlmamýþsa buraya yönlendirilecek
		options.LogoutPath = "/Login/Logout"; // Kullanýcý çýkýþ yapmak için buraya yönlendirilecek
		options.AccessDeniedPath = "/Login/AccessDenied"; // Yetkisiz eriþim sayfasý
		options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Çerez süresi
		options.SlidingExpiration = false; // Kullanýcý aktifse çerez süresi uzatýlacak
	});

// Session kullanýmýný ekleyelim
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


//------------------------------------------------------------------------


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();

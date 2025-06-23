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


// Authentication yap�land�rmas� - Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Kullan�c� giri�i yap�lmam��sa buraya y�nlendirilecek
		options.LogoutPath = "/Login/Logout"; // Kullan�c� ��k�� yapmak i�in buraya y�nlendirilecek
		options.AccessDeniedPath = "/Login/AccessDenied"; // Yetkisiz eri�im sayfas�
		options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // �erez s�resi
		options.SlidingExpiration = false; // Kullan�c� aktifse �erez s�resi uzat�lacak
	});

// Session kullan�m�n� ekleyelim
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

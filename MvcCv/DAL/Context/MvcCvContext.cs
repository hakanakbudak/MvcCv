using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Entities;

namespace MvcCv.DAL.Context
{
	public class MvcCvContext : DbContext
	{
		public MvcCvContext(DbContextOptions<MvcCvContext> options) : base(options)
		{
		}

		public DbSet<TblAdmin> TblAdmin { get; set; }
		public DbSet<TblDeneyimlerim> TblDeneyimlerim { get; set; }
		public DbSet<TblEgitimlerim> TblEgitimlerim { get; set; }
		public DbSet<TblHakkimda> TblHakkimda { get; set; }
		public DbSet<TblHobilerim> TblHobilerim { get; set; }
		public DbSet<Tbliletisim> Tbliletisim { get; set; }
		public DbSet<TblSertifikalarım> TblSertifikalarım { get; set; }
		public DbSet<TblYetenekler> TblYetenekler { get; set; }
		public DbSet<TblSosyalMedya> TblSosyalMedya { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
	public class TblEgitimlerim
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
		public string? Baslik { get; set; }
		
		[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
		public string? AltBaslik1 { get; set; }

		[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
		public string? AltBaslik2 { get; set; }

		
		[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
		[StringLength(4, ErrorMessage = "Lütfen en fazla 4 karakter giriniz")]
		public string? Gno { get; set; }
		
		[Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
		public string? Tarih { get; set; }
	}
}

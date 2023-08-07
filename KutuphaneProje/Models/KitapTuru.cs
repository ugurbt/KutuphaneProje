using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneProje.Models
{
	public class KitapTuru
	{
		[Key] //Primary key 
        public int Id { get; set; }

		[Required(ErrorMessage="Kitap Tür Adı Boş Bırakılamaz!")] // not null
		[MaxLength(25)] // max 25 karakter
		[DisplayName("Kitap Türü Adı")] //view ekranında bu adla gozukecek
		public string Ad { get; set; }

    }
}

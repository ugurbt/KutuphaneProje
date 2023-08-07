using KutuphaneProje.Models;
using KutuphaneProje.Utility;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProje.Controllers
{
	public class KitapTuruController : Controller
	{
		private readonly IKitapTuruRepository _kitapTuruRepository;//dependncy injection

		public KitapTuruController(IKitapTuruRepository context)
		{
			_kitapTuruRepository = context;
		}

		public IActionResult Index()
		{
			List<KitapTuru>objKitapTuruList= _kitapTuruRepository.GetAll().ToList();
			return View(objKitapTuruList);
		}

		public IActionResult Ekle() 
		{ 
			return View();
		}

		[HttpPost]
		public IActionResult Ekle(KitapTuru kitapTuru)
		{
			if (ModelState.IsValid) //Modelden gelen verilerin doğru olup olmadıgını kontrol ediyorum
			{
				_kitapTuruRepository.Ekle(kitapTuru);
				_kitapTuruRepository.Kaydet(); // SaveChanges() yapmazsak bilgiler veritabanına eklenmez.
				TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu! ";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Guncelle(int? id)
		{
			if(id== null || id == 0) 
			{
				return NotFound();
			}
			KitapTuru? kitapTuruVt= _kitapTuruRepository.Get(u=>u.Id==id); //Expression<Func<T, bool>> filtre
			if (kitapTuruVt == null) 
			{
				return NotFound();
			}
			return View(kitapTuruVt);
		}

		[HttpPost]
		public IActionResult Guncelle(KitapTuru kitapTuru)
		{
			if (ModelState.IsValid) //Modelden gelen verilerin doğru olup olmadıgını kontrol ediyorum
			{
				_kitapTuruRepository.Guncelle(kitapTuru);
				_kitapTuruRepository.Kaydet(); // SaveChanges() yapmazsak bilgiler veritabanına eklenmez.
				TempData["basarili"] = "Yeni Kitap Türü Başarıyla Güncellendi! ";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Sil(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
			if (kitapTuruVt == null)
			{
				return NotFound();
			}
			return View(kitapTuruVt);
		}

		[HttpPost, ActionName("Sil")]
		public IActionResult SilPost(int? id)
		{
			KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id);
			if (kitapTuru==null)
			{
				return NotFound();
			}
			_kitapTuruRepository.Sil(kitapTuru);
			_kitapTuruRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme İşlemi Başarılı! ";
			return RedirectToAction("Index");
		}
	}
}

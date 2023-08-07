﻿using KutuphaneProje.Models;
using KutuphaneProje.Utility;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProje.Controllers
{
	public class KitapController : Controller
	{
		private readonly IKitapRepository _kitapRepository;//dependncy injection

		public KitapController(IKitapRepository context)
		{
			_kitapRepository = context;
		}

		public IActionResult Index()
		{
			List<Kitap>objKitapList= _kitapRepository.GetAll().ToList();
			return View(objKitapList);
		}

		public IActionResult Ekle() 
		{ 
			return View();
		}

		[HttpPost]
		public IActionResult Ekle(Kitap kitap)
		{
			if (ModelState.IsValid) //Modelden gelen verilerin doğru olup olmadıgını kontrol ediyorum
			{
				_kitapRepository.Ekle(kitap);
				_kitapRepository.Kaydet(); // SaveChanges() yapmazsak bilgiler veritabanına eklenmez.
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
			Kitap? kitapVt= _kitapRepository.Get(u=>u.Id==id); //Expression<Func<T, bool>> filtre
			if (kitapVt == null) 
			{
				return NotFound();
			}
			return View(kitapVt);
		}

		[HttpPost]
		public IActionResult Guncelle(Kitap kitap)
		{
			if (ModelState.IsValid) //Modelden gelen verilerin doğru olup olmadıgını kontrol ediyorum
			{
				_kitapRepository.Guncelle(kitap);
				_kitapRepository.Kaydet(); // SaveChanges() yapmazsak bilgiler veritabanına eklenmez.
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
			Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
			if (kitapVt == null)
			{
				return NotFound();
			}
			return View(kitapVt);
		}

		[HttpPost, ActionName("Sil")]
		public IActionResult SilPost(int? id)
		{
			Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
			if (kitap==null)
			{
				return NotFound();
			}
			_kitapRepository.Sil(kitap);
			_kitapRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme İşlemi Başarılı! ";
			return RedirectToAction("Index");
		}
	}
}

﻿using System.ComponentModel.DataAnnotations;

namespace KutuphaneProje.Models
{
	public class Kitap
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string KitapAdi { get; set; }

        public string Tanim { get; set; }

		public string Yazar { get; set; }

        [Required]
        [Range(10,5000)]
        public double Fiyat { get; set; }
    }
}

using KutuphaneProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KutuphaneProje.Utility
{
	public class UygulamaDbContext:DbContext
	{
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) 
        { 
         
        }

        public DbSet<KitapTuru> KitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }



	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<Cariler> carilers { get; set; }
        public DbSet<departman> departmans { get; set; }
        public DbSet<faturaKalem> faturaKalems { get; set; }
        public DbSet<Faturalar> faturalars { get; set; }
        public DbSet<Gider> giders { get; set; }
        public DbSet<kategori> kategoris { get; set; }
        public DbSet<personel> personels { get; set; }
        public DbSet<SatisHareket> satisHarekets { get; set; }
        public DbSet<urunler> urunlers { get; set; }
        public DbSet<UrunDetay> urunDetays { get; set; }
        public DbSet<yapilacaklar> yapilacaklars { get; set; }
        public DbSet<kargoTakip> kargoTakips { get; set; }
        public DbSet<kargoDetay> kargoDetays { get; set; }
        public DbSet<mesajlar> mesajlars { get; set; }
    }
}
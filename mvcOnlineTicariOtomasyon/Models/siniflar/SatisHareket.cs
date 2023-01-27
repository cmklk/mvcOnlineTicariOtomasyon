using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }

        // ürün
        // cari 
        // personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int urunid { get; set; }
        public int cariid { get; set; }
        public int personelid { get; set; }
        public virtual urunler urunler { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual personel personel { get; set; }
        

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class Cariler
    {
        [Key]
        public int Cariid { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter girebilirsiniz.")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En Fazla 30 Karakter Girebilirsiniz.")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage ="En Fazla 13 Karakter Girebilirsiniz.")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage ="En Fazla 50 Karakter Girebilirsiniz.")]
        public string Mail { get; set; }


        [Column(TypeName ="Varchar")]
        [StringLength(20, ErrorMessage ="En Fazla 20 Karakter Girmelisiniz.")]
        public string sifre { get; set; }

        

        public bool DURUM { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}
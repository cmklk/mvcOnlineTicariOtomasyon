using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class kargoDetay
    {
        [Key]
        public int kargoDetayId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(200)]
        public string Aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string takipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string personel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string alici { get; set; }

        public DateTime tarih { get; set; }
    }
}
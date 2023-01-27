using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{

    public class UrunDetay
    {
        [Key]
        public int detayId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string detayAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string detayBilgi { get; set; }
    }
}
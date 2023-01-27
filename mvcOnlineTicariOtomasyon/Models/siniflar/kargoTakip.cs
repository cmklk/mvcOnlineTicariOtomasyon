using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class kargoTakip
    {
        [Key]
        public int kargoTakipId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        public string TakipKod { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(200)]
        public string Aciklama { get; set; }

        public DateTime tarihZaman { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class kategori
    {
        [Key]
        public int kategoriID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string kategoriAd { get; set; }
        public ICollection<urunler> urunlers { get; set; }
    }
}
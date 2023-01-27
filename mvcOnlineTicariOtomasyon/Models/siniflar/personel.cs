using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class personel
    {
        [Key]
        public int personelId { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string personelAd { get; set; }

      

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string personelSoyad { get; set; }

       

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string personelGorsel { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set;}
        

        public bool durum { get; set; }
        public int departmanid { get; set; }
        public  virtual departman departman { get; set; }
    }
}
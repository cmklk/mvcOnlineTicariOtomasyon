using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class yapilacaklar
    {
        [Key]
        [Column(TypeName ="int")]
        public int yapilacalId { get; set; }

      
        [Column(TypeName = "Varchar")]
        public string baslik { get; set; }

     
        [Column(TypeName = "bit")]
        public bool durum { get; set; }
    }
}
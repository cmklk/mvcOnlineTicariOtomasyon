using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class mesajlar
    {
        [Key]

        
        public int mesajId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string gonderici { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string alici { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(90)]
        public string konu { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string icerik { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime tarih { get; set; }

    }
}
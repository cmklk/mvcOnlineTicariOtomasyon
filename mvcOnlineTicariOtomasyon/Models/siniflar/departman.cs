using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class departman
    {
        [Key]
        public int DepartmanId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool DURUM { get; set; }
        public ICollection<personel> personels { get; set; }
    }
}
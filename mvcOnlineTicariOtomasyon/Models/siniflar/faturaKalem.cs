﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class faturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat{ get; set; }
        public decimal Tutar { get; set; }
        public int Faturaid { get; set; }
        public virtual Faturalar faturalar { get; set; }
    }
}
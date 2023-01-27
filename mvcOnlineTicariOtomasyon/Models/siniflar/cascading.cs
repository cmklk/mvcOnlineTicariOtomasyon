using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcOnlineTicariOtomasyon.Models.siniflar
{
    public class cascading
    {
        public IEnumerable<SelectListItem> kategoriler { get; set; }
        public IEnumerable<SelectListItem> urunler { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count();
            ViewBag.dr1 = deger1;

            var deger2 = c.kategoris.Count();
            ViewBag.dr2 = deger2;


            var deger3 = c.urunlers.Count();
            ViewBag.dr3 = deger3;

            var deger4 = (from x in c.carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.dr4 = deger4;

            var yapilacakListe = c.yapilacaklars.ToList();
            return View(yapilacakListe);
        }
    }
}
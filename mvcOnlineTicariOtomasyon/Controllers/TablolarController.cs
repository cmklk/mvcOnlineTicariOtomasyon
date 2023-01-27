using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class TablolarController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var sorgu = from x in c.carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult partial1()
        {
            var sorgu2 = from x in c.personels
                         group x by x.departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             departman = g.Key,
                             sayi=g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult partial2()
        {
            var sorgu3 = from x in c.urunlers
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            Marka = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu3.ToList());
        }

        public PartialViewResult partial3()
        {
            var cariList = c.carilers.ToList();
            return PartialView(cariList);
        }

        public PartialViewResult partial4()
        {
            var urunList = c.urunlers.ToList();
            return PartialView(urunList);
        }
    }
}
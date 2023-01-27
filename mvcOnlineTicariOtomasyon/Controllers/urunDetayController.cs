using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class urunDetayController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = c.urunlers.Where(x => x.Urunid == 1).ToList();
            cs.deger2 = c.urunDetays.Where(x => x.detayId == 1).ToList();
            return View(cs);
        }
    }
}
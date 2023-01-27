using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;

namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(x => x.takipKodu.Contains(p));
            }
            return View(k.ToList());
        }


        [HttpGet]
        public ActionResult yeniKargo()
        {

            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D", "E" };
            int K1, K2, K3;
            K1 = rnd.Next(0,4);
            K2 = rnd.Next(0,4);
            K3 = rnd.Next(0,4);

            int S1, S2, S3;
            S1 = rnd.Next(100,1000);
            S2 = rnd.Next(10, 99);
            S3 = rnd.Next(10, 99);

            string kod;
            kod = S1.ToString() + karakter[K1] + S2.ToString() + karakter[K2] + S3.ToString() + karakter[K3];
            ViewBag.rastKod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult yeniKargo(kargoDetay p)
        {
            c.kargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kargoTakipDetay (string id)
        {
            var detay = c.kargoTakips.Where(x => x.TakipKod == id).ToList();
            return View(detay);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class MesajlarController : Controller
    {
        Context c = new Context();
        public ActionResult gelenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var girisYap = c.mesajlars.Where(x => x.alici == mail).ToList();
            var aliciMesajSayisi = c.mesajlars.Where(x => x.alici == mail).Count();
            ViewBag.deger1 = aliciMesajSayisi;
            var gonderilenSayi = c.mesajlars.Where(x => x.gonderici == mail).Count();
            ViewBag.deger2 = gonderilenSayi;
            return View(girisYap);
        }


        public ActionResult gonderilenMesaj()
        {
            var mail = (string)Session["Mail"];
            var gonderilenMesaj = c.mesajlars.Where(x => x.gonderici == mail).OrderByDescending(x=>x.mesajId).ToList();
            var gonderilenSayi = c.mesajlars.Where(x => x.gonderici == mail).Count();
            ViewBag.deger2 = gonderilenSayi;


            var aliciMesajSayisi = c.mesajlars.Where(x => x.alici == mail).Count();
            ViewBag.deger1 = aliciMesajSayisi;
            return View(gonderilenMesaj); 
                
        }


        public ActionResult mesajDetay(int id)
        {
            var detayBilgi = c.mesajlars.Where(x => x.mesajId == id).OrderByDescending(x => x.mesajId).ToList();
            return View(detayBilgi);
                
        }


        [HttpGet]
        public ActionResult yeniMesaj()
        {
            var mail = (string)Session["Mail"];
            var gonderilenSayi = c.mesajlars.Where(x => x.gonderici == mail).Count();
            ViewBag.deger2 = gonderilenSayi;


            var aliciMesajSayisi = c.mesajlars.Where(x => x.alici == mail).Count();
            ViewBag.deger1 = aliciMesajSayisi;
            return View();
        }


        [HttpPost]
        public ActionResult yeniMesaj(mesajlar p)
        {
            var mail = (string)Session["Mail"];
            p.gonderici = mail;
            p.tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.mesajlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("gonderilenMesaj");
        }

        
    }
}
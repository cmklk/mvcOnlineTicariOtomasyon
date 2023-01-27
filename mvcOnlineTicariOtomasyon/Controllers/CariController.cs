using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {

            var CariList = c.carilers.Where(x => x.DURUM == true).ToList().ToPagedList(sayfa,3);
            // var CariList = c.carilers.ToList();
            return View(CariList);
        }

        [HttpGet]
        public ActionResult cariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cariEkle(Cariler cari)
        {
            c.carilers.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cariSil(int id)
        {
            var cariBul = c.carilers.Find(id);
            cariBul.DURUM = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cariVeriGetir(int id)
        {
            var cariler = c.carilers.Find(id);
            return View("cariVeriGetir",cariler);
        }

        public ActionResult cariGuncelle(Cariler cari)
        {

            if (!ModelState.IsValid)
            {
                return View("cariVeriGetir");
            }
                
            var mevcutCari = c.carilers.Find(cari.Cariid);
            mevcutCari.CariAd = cari.CariAd;
            mevcutCari.CariSoyad = cari.CariSoyad;
            mevcutCari.CariSehir = cari.CariSehir;
            mevcutCari.Mail = cari.Mail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult cariSatisGecmis(int id)
        {
            var cari = c.satisHarekets.Where(x => x.cariid == id).ToList();
            var cariBilgi = c.carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.deger1 = cariBilgi;
            return View(cari);
        }
    
    }
}
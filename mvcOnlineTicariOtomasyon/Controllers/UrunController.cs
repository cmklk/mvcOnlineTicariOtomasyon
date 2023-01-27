using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunList = from x in c.urunlers select x;
            if(!string.IsNullOrEmpty(p)) {
                urunList = c.urunlers.Where(x => x.UrunAd.Contains(p));
            }
            return View(urunList.ToList());
        }


        [HttpGet]
        public ActionResult urunEkle()
        {

            List<SelectListItem> urun = (from x in c.kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.kategoriAd,
                                             Value = x.kategoriID.ToString(),

                                         }).ToList();

            ViewBag.dgr = urun;
            return View();
        }

        [HttpPost]
        public ActionResult urunEkle(urunler urn)
        {
            c.urunlers.Add(urn);
            urn.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunSil(int id)
        {
            var Urundurum = c.urunlers.Find(id);
            Urundurum.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult urunGetir(int id)
        {


            List<SelectListItem> urun = (from x in c.kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.kategoriAd,
                                             Value = x.kategoriID.ToString()
                                         }).ToList();
            ViewBag.dgr = urun;
            var urunBul = c.urunlers.Find(id);
            return View("urunGetir",urunBul);
        }


        public ActionResult urunGuncelle(urunler urn)
        {
            var mevcutUrun = c.urunlers.Find(urn.Urunid);
            mevcutUrun.UrunAd = urn.UrunAd;
            mevcutUrun.Marka = urn.Marka;
            mevcutUrun.Stok = urn.Stok;
            mevcutUrun.AlisFiyat = urn.AlisFiyat;
            mevcutUrun.SatisFiyat = urn.SatisFiyat;
            mevcutUrun.Kategoriid = urn.Kategoriid;
            mevcutUrun.UrunGorsel = urn.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult urunListesi()
        {
            var urunler = c.urunlers.ToList();
            return View(urunler);
        }



        [HttpGet]
        public ActionResult satisYap(int id)
        {

            List<SelectListItem> personel = (from x in c.personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.personelAd + " " + x.personelSoyad,
                                                 Value = x.personelId.ToString()
                                             }).ToList();
            ViewBag.deger1 = personel;
            var urunID = c.urunlers.Find(id);
            ViewBag.deger2 = urunID.Urunid;
            ViewBag.deger3 = urunID.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult satisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }





    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var SatisList = c.satisHarekets.ToList();
            return View(SatisList);
        }


        [HttpGet]
        public ActionResult satisEkle()
        {
            List<SelectListItem> cari = (from x in c.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + ' ' + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();


            List<SelectListItem> personel = (from x in c.personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.personelAd + ' ' + x.personelSoyad,
                                                 Value = x.personelId.ToString()
                                         }).ToList();


            List<SelectListItem> urun = (from x in c.urunlers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.Urunid.ToString()
                                         }).ToList();

            ViewBag.deger1 = cari;
            ViewBag.deger2 = personel;
            ViewBag.deger3 = urun;
            return View();
        }


        [HttpPost]
        public ActionResult satisEkle(SatisHareket p)
        {
           p.Tarih= DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satisHarekets.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult satisDetay(int id)
        {
            List<SelectListItem> cari = (from x in c.carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd +" "+x.CariSoyad,
                                             Value = x.Cariid.ToString()
                                         }).ToList();

          

            List<SelectListItem> personel = (from x in c.personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.personelAd +" "+x.personelSoyad,
                                             Value = x.personelId.ToString()
                                         }).ToList();
           

            List<SelectListItem> urunler = (from x in c.urunlers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.Urunid.ToString()
                                         }).ToList();

            ViewBag.deger1 = cari;
            ViewBag.deger2 = personel;
            ViewBag.deger3 = urunler;
            var satisBilgi = c.satisHarekets.Find(id);
            return View("satisDetay", satisBilgi);
        }



       


        public ActionResult satisDetay2 (int id)
        {
            var satisHareket = c.satisHarekets.Where(x => x.SatisId == id).ToList();
            return View(satisHareket);
        }
    }
}
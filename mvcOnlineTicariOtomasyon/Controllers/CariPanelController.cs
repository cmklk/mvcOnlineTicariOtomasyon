using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        Context c = new Context();
       

        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var deger = c.carilers.Where(x => x.Mail == mail).ToList();
            ViewBag.deger1 = mail;


            var cariId = c.carilers.Where(x => x.Mail == mail).Select(x => x.Cariid).FirstOrDefault();
            var satisUrunSayi = c.satisHarekets.Where(x => x.cariid == cariId).Count();
            ViewBag.deger2 = satisUrunSayi;



          
            var toplamSatisHarcama = c.satisHarekets.Where(x => x.cariid == cariId).Sum(x => x.ToplamTutar);
            ViewBag.deger3 = toplamSatisHarcama;


          
            var toplamUrunSayisi = c.satisHarekets.Where(x => x.cariid == cariId).Sum(x => x.Adet);
            ViewBag.deger4 = toplamUrunSayisi;

            return View(deger);
        }


        public ActionResult siparisGecmis()
        {
            var mail = (string)Session["Mail"];
            var cariID = c.carilers.Where(x => x.Mail == mail).Select(y => y.Cariid).FirstOrDefault();
            var satisHareket = c.satisHarekets.Where(x => x.cariid == cariID).ToList();
            return View(satisHareket);
        }



        public PartialViewResult partial2()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = c.mesajlars.Where(x => x.alici == mail).ToList();
            return PartialView(mesajlar);
        }


        public PartialViewResult partial3()
        {

            var mail = (string)Session["Mail"];
            var cariId = c.carilers.Where(x => x.Mail == mail).Select(y=>y.Cariid).FirstOrDefault();
            var cariBul = c.carilers.Find(cariId);
            return PartialView("partial3",cariBul);
        }


        public ActionResult cariPanelGuncelle(Cariler p)
        {
            var mevcutCari = c.carilers.Find(p.Cariid);
            
            mevcutCari.CariAd = p.CariAd;
            mevcutCari.CariSoyad = p.CariSoyad;
            mevcutCari.CariSehir = p.CariSehir;
            mevcutCari.Mail = p.Mail;
            mevcutCari.sifre = p.sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        } 


        public ActionResult cariPanelKargoTakip(string p)
        {
            var kargoTakipListesi = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargoTakipListesi = c.kargoDetays.Where(x => x.takipKodu.Contains(p));
            }
            return View(kargoTakipListesi.ToList());
        }


        public ActionResult kargodetayBilgi(string id)
        {
            var sonuc = c.kargoTakips.Where(x => x.TakipKod == id).ToList();
            return View(sonuc);
        }


        public ActionResult cikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}
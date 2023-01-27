using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {

        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {

            var kategoriList = c.kategoris.ToList().ToPagedList(sayfa,2);
            return View(kategoriList);
        }


        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult kategoriEkle(kategori ktgr)
        {
            c.kategoris.Add(ktgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriSil(int id)
        {
            var kategoriFind = c.kategoris.Find(id);
            c.kategoris.Remove(kategoriFind);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategoriGetir(int id)
        {
            var kategoriGetir = c.kategoris.Find(id);
            return View("kategoriGetir",kategoriGetir);
        }

        public ActionResult kategoriGuncelle(kategori ktgr)
        {
            var kategori = c.kategoris.Find(ktgr.kategoriID);
            kategori.kategoriAd = ktgr.kategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult categoryAndProduct()
        {
            cascading cs = new cascading();
            cs.kategoriler = new SelectList(c.kategoris, "kategoriID", "kategoriAd");
            cs.urunler = new SelectList(c.urunlers, "Urunid", "UrunAd");
            return View(cs);
        }

        public ActionResult urunGetir(int p)
        {
            var urunListesi = (from x in c.urunlers
                               join y in c.kategoris
                               on x.kategori.kategoriID equals y.kategoriID
                               where x.kategori.kategoriID == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value = x.Urunid.ToString()
                               }).ToList();
            return Json(urunListesi, JsonRequestBehavior.AllowGet);
        }
    }
}
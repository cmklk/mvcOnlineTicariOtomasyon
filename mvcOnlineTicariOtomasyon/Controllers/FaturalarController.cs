using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var faturalar = c.faturalars.ToList();
            return View(faturalar);
        }


        [HttpGet]
        public ActionResult faturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult faturaEkle(Faturalar p)
        {
            c.faturalars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult faturaGetir(int id)
        {
            var bilgiler = c.faturalars.Find(id);
            return View("faturaGetir",bilgiler);
        }

        public ActionResult faturaGuncelle(Faturalar p)
        {
            var fatura = c.faturalars.Find(p.Faturaid);
            fatura.FaturaSeriNo = p.FaturaSeriNo;
            fatura.FaturaSıraNo = p.FaturaSıraNo;
            fatura.Tarih = p.Tarih;
            fatura.TeslimAlan = p.TeslimAlan;
            fatura.TeslimEden = p.TeslimEden;
            fatura.Saat = p.Saat;
            fatura.VergiDairesi = p.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaKalem(int id)
        {
            var faturaKalem = c.faturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(faturaKalem);
        }


        [HttpGet]
        public ActionResult yeniFaturaKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniFaturaKalem(faturaKalem p)
        {
            c.faturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


       

     
    }
}
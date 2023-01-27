using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class departmanController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var departmanList = c.departmans.Where(x => x.DURUM == true).ToList();
            return View(departmanList);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult departmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult departmanEkle(departman dprt)
        {
            c.departmans.Add(dprt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanSil(int id)
        {
            var departman = c.departmans.Find(id);
            departman.DURUM = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

      

        public ActionResult departmanVeriGetir(int id)
        {
            var DepartmanVeri = c.departmans.Find(id);
            return View("departmanVeriGetir", DepartmanVeri);
        }
        
        public ActionResult departmanGuncelle (departman dprt)
        {
            var departman = c.departmans.Find(dprt.DepartmanId);
            departman.DepartmanAd = dprt.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanDetay(int id)
        {
            var deger = c.personels.Where(x => x.departmanid == id).ToList();
            var departmans = c.departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.deger1 =departmans ;
            return View(deger);
        }

        public ActionResult departmanDetaySatis(int id)
        {
            var hareket = c.satisHarekets.Where(x => x.personelid == id).ToList();
            var personels = c.personels.Where(x => x.personelId == id).Select(y => y.personelAd).FirstOrDefault();
            ViewBag.deger2 = personels;
            return View(hareket);
        }
    }
}
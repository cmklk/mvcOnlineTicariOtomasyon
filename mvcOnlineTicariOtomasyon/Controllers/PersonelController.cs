using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var personelList = c.personels.Where(x=>x.durum==true).ToList();
            return View(personelList);
        }


        [HttpGet]
        public ActionResult personelEkle()
        {

            List<SelectListItem> departman = (from x in c.departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanId.ToString()
                                              }).ToList();
            ViewBag.deger1 = departman;
                
            return View();
        }

        [HttpPost]
        public ActionResult personelEkle(personel pers)
        {
            if (Request.Files.Count > 0) // istekte bulunduğum bir dosya vars
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                pers.personelGorsel = "/image/" + dosyaAdi + uzanti;
            }

            var personelEkle = c.personels.Add(pers);
            personelEkle.durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelSil(int id)
        {
            var personelSil = c.personels.Find(id);
            personelSil.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelVeriGetir(int id)
        {

            List<SelectListItem> departman = (from x in c.departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();

            ViewBag.departmanAd = departman;
            var personelVeri = c.personels.Find(id);
            return View("personelVeriGetir",personelVeri);
        }


        public ActionResult personelGuncelle(personel p)
        {
            if (Request.Files.Count > 0) // istekte bulunduğum bir dosya vars
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/image/" + dosyaAdi + uzanti;
            }
            var personel = c.personels.Find(p.personelId);
            personel.personelAd = p.personelAd;
            personel.personelSoyad = p.personelSoyad;
            personel.personelGorsel = p.personelGorsel;
            personel.departmanid = p.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelBilgi()
        {
            var personelList = c.personels.ToList();
            return View(personelList);
        }
    }
}
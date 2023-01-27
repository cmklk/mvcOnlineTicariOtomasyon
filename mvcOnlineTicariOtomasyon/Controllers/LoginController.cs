using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
   [AllowAnonymous]
    public class LoginController : Controller
    {


        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult partialRegisterPanel()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult partialRegisterPanel(Cariler cari)
        {
            c.carilers.Add(cari);
            c.SaveChanges();
            return PartialView();
        }



        [HttpGet]
        public ActionResult cariLoginGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cariLoginGiris(Cariler p)
        {
            var CariBilgi = c.carilers.FirstOrDefault(x => x.Mail == p.Mail && x.sifre == p.sifre);

            if (CariBilgi != null)
            {
                FormsAuthentication.SetAuthCookie(CariBilgi.Mail, false);
                Session["Mail"] = CariBilgi.Mail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }

            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }


        [HttpGet]
        public ActionResult AdminLoginGiris()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminLoginGiris(Admin p)
        {
            var adminBilgiler = c.admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);

            if (adminBilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(adminBilgiler.KullaniciAd, false);
                Session["kullaniciAd"] = adminBilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }

            else
            {
                return RedirectToAction("Index","Login");
            }
         
        }

    }
}
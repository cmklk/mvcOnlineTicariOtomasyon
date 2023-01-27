using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistiklerController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var toplamCari = c.carilers.Count();
            ViewBag.deger1 = toplamCari;

             var urunler = c.urunlers.Count();
            ViewBag.deger2 = urunler;

            var personel = c.personels.Count();
            ViewBag.deger3 = personel;

            var kategori = c.kategoris.Count();
            ViewBag.deger4 = kategori;


            var stok = c.urunlers.Sum(x => x.Stok);
            ViewBag.deger5 = stok;


            var marka = (from x in c.urunlers select x.Marka).Distinct().Count().ToString();
            ViewBag.deger6 = marka;

            var kritik = c.urunlers.Count(x => x.Stok <= 20).ToString();
            ViewBag.deger7 = kritik;


            var maxFiyatUrun = (from x in c.urunlers orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.deger8 = maxFiyatUrun;


            var minFiyatUrun = (from x in c.urunlers orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.deger9 = minFiyatUrun;


            var maxMarka = c.urunlers.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.deger10 = maxMarka;


            var buzdolabı = c.urunlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.deger11 = buzdolabı;

            var laptop = c.urunlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.deger12 = laptop;


            var encokSatan = c.urunlers.Where(u => u.Urunid == (c.satisHarekets.GroupBy(x => x.urunid).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(t => t.UrunAd).FirstOrDefault();
            ViewBag.deger13 = encokSatan;
            var kasaToplamTutar = c.satisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.deger14 = kasaToplamTutar;


            DateTime bugun = DateTime.Today;
            var bugunSatis = c.satisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.deger15 = bugunSatis;



            var bugunKasa = c.satisHarekets.Where(x => x.Tarih == bugun).Sum(y=> (decimal?)y.ToplamTutar).ToString();
            ViewBag.deger16 = bugunKasa;
            return View();
        }
    }
}
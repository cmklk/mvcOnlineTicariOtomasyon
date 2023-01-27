using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.siniflar;
namespace mvcOnlineTicariOtomasyon.Controllers
{

    public class ChartController : Controller
    {
        Context c = new Context();


        // GET: Chart
        public ActionResult Index()
        {
            var grafik = new Chart(width: 500, height: 500);
            grafik.AddTitle(text: "Kategoriler ve Ürün Sayıları");
            grafik.AddLegend(title: "Değerler");

            grafik.AddSeries(
                name: "Veriler",
                chartType: "Doughnut",
                xValue: new[]
                {
            "BEYAZ EŞYA","TELEVİZYON", "BİLGİSAYAR","KÜÇÜK EV ALETLERİ"
                },

                yValues: new[] { 500, 250, 340, 620 }
                ).Write();

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }


        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.urunlers.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));

            var grafik = new Chart(width: 500, height: 500)
                .AddTitle(text: "ÜRÜN STOK BİLGİLERİ")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yValue);
            return File(grafik.ToWebImage().GetBytes(), "image/png");
        }


        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult() //görselleştirmek
        {
            return Json(urunListesi(), JsonRequestBehavior.AllowGet);  //json request behaivor
        }


        public List<sinif1> urunListesi()
        {
            List<sinif1> degerler = new List<sinif1>();
            degerler.Add(new sinif1()
            {
                urunAd = "Bilgisayar",
                stok = 20
            });

            degerler.Add(new sinif1()
            {
                urunAd = "Bulaşık Makinesi",
                stok = 30
            });

            degerler.Add(new sinif1()
            {
                urunAd = "Buzdolabi",
                stok = 40
            });

            return degerler;
        }




        // grafik veri tabanından verileri çekme

        public ActionResult index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(urunListesi2(), JsonRequestBehavior.AllowGet);
        }


        public List<sinif2Chart> urunListesi2()
        {
            List<sinif2Chart> snf = new List<sinif2Chart>();
            using (var c =new Context())
            {
                snf = c.urunlers.Select(x => new sinif2Chart

                {
                    urn =x.UrunAd,
                    stk =x.Stok
                }).ToList();   
            }
            return snf;
        }



        public ActionResult index6()
        {
            return View();
        }


        public ActionResult VisualizeFaturaResult()
        {
            return Json(FaturaListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<faturaFiyatChart> FaturaListesi()
        {
            List<faturaFiyatChart> snf = new List<faturaFiyatChart>();
            using(var c = new Context())
            {
                snf = c.faturalars.Select(x => new faturaFiyatChart
                {
                   
                    siraBilgi = x.FaturaSıraNo,
                    toplamFiyat =x.Toplam
                   
                }).ToList();
            }
            return snf;
        }

       


    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcOtomasyon.Models.Entity;

namespace MvcOtomasyon.Controllers
{
    public class UrunController : Controller

    {
        // GET: Urun
        otomasyonEntities db = new otomasyonEntities();
        public ActionResult Index()
        {
            var urunler = db.URUNLER.ToList();

            return View(urunler);
        }
        [HttpGet] // eğerki sayfa ilk yükleniyorsa, bir işlem yoksa sadece view'i geri döndür
        public ActionResult YeniUrun()
        {

            // LINQ İle sorgulama yaptık - DropdownList için db'den veri seçme [Ürün ekleme yaparken kullanacağız.]
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler; // Controller tarafındaki ifadeyi diğer tarafa taşıyacağız - nesne türetip orada kullanacağız.


            return View();
            
        }


        [HttpPost] // sayfaya herhangi bir post işlemi yapıldığı zaman:
        public ActionResult YeniUrun(URUNLER p1)
        {   // firstOrDefault : Seçmiş Olduğum İlk Değeri getir.
            var kategori = db.KATEGORILER.Where(m => m.KATEGORIID == p1.KATEGORILER.KATEGORIID).FirstOrDefault();
            p1.KATEGORILER = kategori;

            db.URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index"); // Kayıt etme işi tamamlanınca Index sayfasına geri döndür
        }

        public ActionResult SIL(int id)
        {
            var urun = db.URUNLER.Find(id); //urunlerde id yi bul
            db.URUNLER.Remove(urun); //buldugunu urunlerden kaldir
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            var urun = db.URUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler; // Controller tarafındaki ifadeyi diğer tarafa taşıyacağız - nesne türetip orada kullanacağız.


          
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(URUNLER p)
        {
            var urun = db.URUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.URUNMARKA = p.URUNMARKA;
            urun.FIYAT = p.FIYAT;
            urun.URUNMODEL = p.URUNMODEL;
            urun.STOK = p.STOK;
            // urun.KATEGORIID = p.KATEGORIID;

            var kategori = db.KATEGORILER.Where(m => m.KATEGORIID == p.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.KATEGORIID = kategori.KATEGORIID;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}
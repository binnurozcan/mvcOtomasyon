
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity; //entity klasorune ulas

namespace MvcOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        //modeli tanit
        otomasyonEntities db = new otomasyonEntities(); //turettigim nesne modelimi tutuyor(tablolar)
        public ActionResult Index()
        {
            var kategoriler = db.KATEGORILER.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost] //forma bir gonderme post yaparsam yap //sayfa yuklendigi zaman yani post yapildigi zaman bu islemi gerceklestir
        //kategori ekle
        public ActionResult YeniKategori(KATEGORILER p1) //Kategori ekleme
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.KATEGORILER.Add(p1); //ekle
            db.SaveChanges(); //kaydet
            
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id) //kategori silme
        {
            var kategori = db.KATEGORILER.Find(id); //tablo icinde id den gelen degeri bul
            db.KATEGORILER.Remove(kategori); //kategoriden gelen degeri sil
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id) //id ye gore kategori geyir
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr); //kategorigetir icinden ktgrden gelen degerleri dondur
        }
        public ActionResult Guncelle(KATEGORILER p1)
        {
            var ktg = db.KATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
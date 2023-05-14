using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;

namespace MvcOtomasyon.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        otomasyonEntities db = new otomasyonEntities();
        public ActionResult Index()
        {
            var musteriler = db.MUSTERILER.ToList();

            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.MUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.MUSTERILER.Find(id); //urunlerde id yi bul
            db.MUSTERILER.Remove(musteri); //buldugunu urunlerden kaldir
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(MUSTERILER p1)
        {
            var musteri = db.MUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            musteri.MUSTERITELNO = p1.MUSTERITELNO;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
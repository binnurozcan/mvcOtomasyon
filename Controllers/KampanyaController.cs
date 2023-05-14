using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;

namespace MvcOtomasyon.Controllers
{
    public class KampanyaController : Controller
    {
        // GET: Kampanya
        otomasyonEntities db = new otomasyonEntities();
        public ActionResult Index()
        {
            var kampanyalar = db.KAMPANYALAR.ToList();
            return View(kampanyalar);
        }
        [HttpGet]
        public ActionResult YeniKampanya()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKampanya(KAMPANYALAR p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKampanya");
            }
            db.KAMPANYALAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var kampanya = db.KAMPANYALAR.Find(id); //urunlerde id yi bul
            db.KAMPANYALAR.Remove(kampanya); //buldugunu urunlerden kaldir
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KampanyaGetir(int id)
        {
            var kmp = db.KAMPANYALAR.Find(id);
            return View("KampanyaGetir", kmp);
        }

        public ActionResult Guncelle(KAMPANYALAR p1)
        {
            var kampanya = db.KAMPANYALAR.Find(p1.KAMPANYAID);
            kampanya.KAMPANYAADI = p1.KAMPANYAADI;
            kampanya.KAMPANYAACIKLAMA = p1.KAMPANYAACIKLAMA;
            kampanya.INDIRIMORANI = p1.INDIRIMORANI;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtomasyon.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcOtomasyon.Controllers
{
    public class KampanyaController : Controller
    {
        // GET: Kampanya
        otomasyonEntities db = new otomasyonEntities(); //turettigim nesne modelimi tutuyor(tablolar)
        public ActionResult Index(int sayfa=1) //sayfanin ilk degeri 1
        {
            var kampanyalar = db.KAMPANYALAR.ToList().ToPagedList(sayfa, 7);
            return View(kampanyalar);
        }
        [HttpGet]
        public ActionResult YeniKampanya()
        {
            return View();
        }
        [HttpPost] //forma bir gonderme post yaparsam yap //sayfa yuklendigi zaman yani post yapildigi zaman bu islemi gerceklestir
        //kategori ekle
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Youtube.Models;

namespace Mvc_Youtube.Controllers
{
    public class MusteriController : Controller
    {
        YoutubeMvcStokEntities db = new YoutubeMvcStokEntities();
        // GET: Musteri
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblMusteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TblMusteri.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TblMusteri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TblMusteri.Find(id);
            db.TblMusteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TblMusteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TblMusteri p1)
        {
            var musteri = db.TblMusteri.Find(p1.MusteriID);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
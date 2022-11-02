using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Youtube.Models;
namespace Mvc_Youtube.Controllers
{
    public class UrunController : Controller
    {
        YoutubeMvcStokEntities db = new YoutubeMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TblUrun.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TblUrun p1)
        {
            
            var ktg = db.TblKategori.Where(m => m.KategoriID == p1.TblKategori.KategoriID).FirstOrDefault();
            p1.TblKategori = ktg;
            db.TblUrun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TblUrun.Find(id);
            db.TblUrun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrun.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
           
            return View("UrunGetir", urun);
        }
        
        public ActionResult Guncelle(TblUrun p)
        {
            int id = p.UrunID;
            var urun = db.TblUrun.Find(id);
            urun.UrunAd = p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.Fiyat = p.Fiyat;
            //urun.UrunKategori = p.UrunKategori;
            //var ktgr = db.TblKategori.Where(m => m.KategoriID == p.UrunKategori).FirstOrDefault();
            //urun.UrunKategori = ktgr.KategoriID;

            urun.UrunKategori = p.TblKategori.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
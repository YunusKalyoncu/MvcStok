using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Mvc_Youtube.Models;

namespace Mvc_Youtube.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        YoutubeMvcStokEntities db = new YoutubeMvcStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TblKategori.ToList();
            var degerler = db.TblKategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
              
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategori.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(TblKategori p1)
        {
            var ktgr = db.TblKategori.Find(p1.KategoriID);
            ktgr.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Youtube.Models;

namespace Mvc_Youtube.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        YoutubeMvcStokEntities db = new YoutubeMvcStokEntities(); 
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatıs p)
        {
            db.TblSatıs.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}
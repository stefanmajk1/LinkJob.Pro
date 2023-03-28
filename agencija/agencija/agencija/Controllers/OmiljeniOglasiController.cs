using agencija.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class OmiljeniOglasiController : Controller
    {
        Agencija_Context db = new Agencija_Context();
        

        public ActionResult Delete1(int id)
        {
            
            using (db = new Agencija_Context())
            {
                OmiljeniOglasi og = db.OmiljeniOglasis.Where(x => x.OglasId == id).FirstOrDefault();
                
                db.OmiljeniOglasis.Remove(og);
                db.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Delete(int? id)
        {
            int sessionId = (int)Session["idKorisnik"];
            var likedAd = db.OmiljeniOglasis.FirstOrDefault(x => x.OglasId == id && x.KorisnikId == sessionId);

            if (likedAd != null)
            {
                db.OmiljeniOglasis.Remove(likedAd);
                db.SaveChanges();
            }

            return RedirectToAction("Index");


        }

        

        // GET: OmiljeniOglasi
        public ActionResult Index()
        {
            int sessionId = (int)Session["idKorisnik"];

            var likedAds = db.OmiljeniOglasis.Where(a => a.KorisnikId == sessionId).ToList();

            return View(likedAds);
        }


    }
}
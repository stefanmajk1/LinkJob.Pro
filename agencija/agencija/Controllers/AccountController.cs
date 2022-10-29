using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using agencija.Models;

namespace agencija.Controllers
{
    public class AccountController : Controller
    {
        Agencija_Context db = new Agencija_Context();
        // GET: Account

        [HttpGet]
        public ActionResult Register()
        {
            Korisnik k = new Korisnik();
            return View(k);
        }

        [HttpPost]
        public ActionResult Register(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                using(db = new Agencija_Context())
                {
                    k.idRola = 3;
                    db.Korisniks.Add(k);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = k.Ime + " " + k.Prezime + " successfully registered.";
            }
            return View("Register", new Korisnik());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Korisnik k)
        {
            using(db = new Agencija_Context())
            {
                var usr = db.Korisniks.Single(u => u.Username == k.Username && u.Sifra == k.Sifra);
                if(usr != null)
                {
                    Session["idKorisnik"] = usr.IdKorisnik;

                    HttpCookie cookie = new HttpCookie("MyCookie");
                    cookie.Value = usr.IdKorisnik.ToString();
                    cookie.Expires = DateTime.Now.AddHours(10);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home", k);
                }
                else
                {
                    return View("Login", k);
                    ViewBag.ErrorGreska = "Error";
                }
            }
            

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using agencija.Models;
using Microsoft.AspNetCore.Http;

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
                using (db = new Agencija_Context())
                {
                    if (db.Korisniks.Any(x => x.Username == k.Username))
                    {
                        ModelState.AddModelError("Username", "An account with this username already exists.");
                    }
                    else if (db.Korisniks.Any(x => x.Email == k.Email))
                    {
                        ModelState.AddModelError("Email", "An account with this email already exists.");
                    }
                    else
                    {
                        k.idRola = 3;
                        db.Korisniks.Add(k);
                        db.SaveChanges();
                        TempData["Message"] = k.Ime + " " + k.Prezime + " successfully registered.";
                        ModelState.Clear();
                    }
                }
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
                var usr = db.Korisniks.SingleOrDefault(u => u.Username == k.Username && u.Sifra == k.Sifra);
                if (usr != null)
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
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return View(k);
                }
            }
            

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult UserAccount()
        {
            Korisnik k = new Korisnik();

            var value = Request.Cookies["MyCookie"].Value;

            string idKorisnikString = value;

            int idKorisnik = int.Parse(idKorisnikString);

            k = db.Korisniks.Where(i => i.IdKorisnik == idKorisnik).SingleOrDefault();

            ViewBag.Ime = k.Ime;

            return View(k);
        }

        [HttpPost]
        public ActionResult UserAccount(Korisnik k, HttpPostedFileBase image)
        {
           
            using(var context = new Agencija_Context())
            {
                var userToUpdate = context.Korisniks.Find(k.IdKorisnik);
                if(userToUpdate != null)
                {
                    userToUpdate.Ime = k.Ime;
                    userToUpdate.Prezime = k.Prezime;
                    userToUpdate.Sifra = k.Sifra;
                    userToUpdate.Telefon = k.Telefon;
                    userToUpdate.Email = k.Email;
                    userToUpdate.Username = k.Username;
                    
                    if(image != null)
                    {
                        userToUpdate.Slika = new byte[image.ContentLength];
                        image.InputStream.Read(userToUpdate.Slika, 0, image.ContentLength);
                    }
                    context.SaveChanges();
                    return RedirectToAction("UserAccount");
                }
                return View();
            }
        }
        
    }
}
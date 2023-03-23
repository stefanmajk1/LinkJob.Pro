using agencija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class AdminController : Controller
    {
        Agencija_Context db = new Agencija_Context();
        // GET: Admin
        
        public async Task<ActionResult> Index()
        {
            return View(await db.Korisniks.ToListAsync());
        }

        public async Task<ActionResult> Kompanije()
        {
            return View(await db.Kompanijas.ToListAsync());
        }

        public async Task<ActionResult> Korisnici()
        {
            List<Korisnik> korisnik = (from o in db.Korisniks
                                       where o.idRola == 3
                                       select o).ToList();

            return View( korisnik);
        }

        public async Task<ActionResult> DetailsKompanija(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Kompanija k = await db.Kompanijas.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }

        public async Task<ActionResult> DetailsKorisnici(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if(k == null)
            {
                return HttpNotFound();
            }
            return View(k);        
        }

        [HttpGet]
        public ActionResult CreateKorisnici()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateKorisnici(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                db.Korisniks.Add(k);
                await db.SaveChangesAsync();
                return RedirectToAction("Korisnici");
            }
            return View(k);
        }

        [HttpGet]
        public ActionResult CreateKompanije()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateKompanije(Kompanija k)
        {
            if (ModelState.IsValid)
            {
                db.Kompanijas.Add(k);
                await db.SaveChangesAsync();
                return RedirectToAction("Kompanije");
            }
            return View(k);
        }


        [HttpGet]
        public async Task<ActionResult> EditKompanije(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Kompanija k = await db.Kompanijas.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditKompanije(Kompanija k)
        {
            if (ModelState.IsValid)
            {
                db.Entry(k).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(k);
        }

        [HttpGet]
        public async Task<ActionResult> EditKorisnici(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if(k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditKorisnici(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                db.Entry(k).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Korisnici");
            }
            return View(k);
        }

        public async Task<ActionResult> DeleteKompanija(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompanija k = await db.Kompanijas.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        [HttpPost, ActionName("DeleteKompanija")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed2(int id)
        {
            Kompanija student = await db.Kompanijas.FindAsync(id);
            db.Kompanijas.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Kompanije");
        }

        public async Task<ActionResult> DeleteKorisnika(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteKorisnika")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Korisnik student = await db.Korisniks.FindAsync(id);
            db.Korisniks.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Korisnici");
        }

        

        [HttpGet]
        public ActionResult CreateAgent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAgent(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                db.Korisniks.Add(k);
                await db.SaveChangesAsync();
                return RedirectToAction("Agenti");
            }
            return View(k);
        }


        public async Task<ActionResult> Agenti()
        {
            List<Korisnik> korisnik = (from o in db.Korisniks
                                       where o.idRola == 4
                                       select o).ToList();

            return View(korisnik);
        }

        public async Task<ActionResult> DeleteAgent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteAgent")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed3(int id)
        {
            Korisnik student = await db.Korisniks.FindAsync(id);
            db.Korisniks.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Agenti");
        }

        [HttpGet]
        public async Task<ActionResult> EditAgent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAgent(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                db.Entry(k).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Agenti");
            }
            return View(k);
        }

        public async Task<ActionResult> DetailsAgent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Korisnik k = await db.Korisniks.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        [HttpGet]
        public ActionResult AgentLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgentLogIn(Korisnik k)
        {
            using (db = new Agencija_Context())
            {
                var usr = db.Korisniks.SingleOrDefault(u => u.Username == k.Username && u.Sifra == k.Sifra);
                if (usr != null)
                {
                    Session["idAdmin"] = usr.IdKorisnik;

                    HttpCookie cookie = new HttpCookie("MyCookie");
                    cookie.Value = usr.IdKorisnik.ToString();
                    cookie.Expires = DateTime.Now.AddHours(10);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Kompanije", "Admin");
                }
                else
                {
                    ViewBag.ErrorGreska = "Wrong usernage or password!";
                    return View(k);
                }
            }

        }
    }
}
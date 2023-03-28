using agencija.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class PoslodavacController : Controller
    {
        public PoslodavacController()
        {
            db = new Agencija_Context();

        }



        Agencija_Context db = new Agencija_Context();
        // GET: Poslodavac

        [HttpGet]
        public ActionResult Index()
        {
            int sessionId = (int)Session["idKompanija"];
            Kompanija kompanija = db.Kompanijas.Where(k => k.IdKompanija == sessionId).SingleOrDefault();
            return View(kompanija);
        }

        [HttpPost]
        public ActionResult Index(Kompanija k, HttpPostedFileBase image)
        {
            using(var context = new Agencija_Context())
            {
                var kompanijaToUpdate = context.Kompanijas.Find(k.IdKompanija);

                if(kompanijaToUpdate != null)
                {
                    kompanijaToUpdate.video = k.video;
                    kompanijaToUpdate.sajt = k.sajt;
                    kompanijaToUpdate.opis = k.opis;
                    kompanijaToUpdate.naziv = k.naziv;
                    kompanijaToUpdate.adresa = k.adresa;
                    kompanijaToUpdate.telefon = k.telefon;
                    kompanijaToUpdate.pib = k.pib;
                    if(image != null)
                    {
                        kompanijaToUpdate.logo = new byte[image.ContentLength];
                        image.InputStream.Read(kompanijaToUpdate.logo, 0, image.ContentLength);
                    }
                    context.SaveChanges();
                    TempData["IzmenaKompanije"] ="Your changes were successfull!";
                    return RedirectToAction("Index", new { success = true });
                }
                return View();
            }
        }

        

        [HttpGet]
        public async Task<ActionResult> AgentiKompanija()
        {
            int sessionId = (int)Session["idKompanija"];
            List<Korisnik> korisnik = (from k in db.Korisniks
                                       where k.idRola == 5 && k.idKompanija == sessionId
                                       select k).ToList();

            return View(korisnik);
        }



        public async Task<ActionResult> DetailsAgentiKompanija(int? id)
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
        public ActionResult CreateAgentiKompanija()
        {
            int sessionId = (int)Session["idKompanija"];
            ViewBag.IdKompanija = sessionId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAgentiKompanija(Korisnik k)
        {
            int sessionId = (int)Session["idKompanija"];
            k.idRola = 5;
            k.idKompanija = sessionId;

            if (ModelState.IsValid)
            {
                db.Korisniks.Add(k);
                await db.SaveChangesAsync();
                return RedirectToAction("AgentiKompanija");
            }
            return View(k);
        }
        [HttpGet]
        public async Task<ActionResult> EditAgentiKompanija(int? id)
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
        public async Task<ActionResult> EditAgentiKompanija(Korisnik k)
        {
            if (ModelState.IsValid)
            {
                db.Entry(k).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AgentiKompanija");
            }
            return View(k);
        }

        public async Task<ActionResult> DeleteAgentiKompanija(int? id)
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
        [HttpPost, ActionName("DeleteAgentiKompanija")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Korisnik student = await db.Korisniks.FindAsync(id);
            db.Korisniks.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("AgentiKompanija");
        }

        [HttpGet]
        public async Task<ActionResult> OglasiKompanija(int? id)
        {
            if(Session["idKompanija"] != null)
            {
                int sessionId = (int)Session["idKompanija"];
                List<Ogla> oglas = (from o in db.Oglas
                                    where o.IdKompanija == sessionId
                                    select o).ToList();

                return View(oglas);
            }
            else
            {
                int sessionId = (int)Session["idAgentKompanije"];
                List<Ogla> oglas = (from o in db.Oglas
                                    where o.IdKompanija == sessionId
                                    select o).ToList();

                return View(oglas);
            }
           
        }

        public async Task<ActionResult> DetailsOglasaKompanije(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Ogla k = await db.Oglas.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        public async Task<ActionResult> DeleteOglasKompanije(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogla k = await db.Oglas.FindAsync(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View(k);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteOglasKompanije")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed2(int id)
        {
            Ogla student = await db.Oglas.FindAsync(id);
            db.Oglas.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("OglasiKompanija", TempData["Brisi"] = "You deleted the job ad!");
        }
        [HttpGet]
        public async Task<ActionResult> OglasiKandidati()
        {
            if (Session["idKompanija"] != null)
            {
                int sessionId = (int)Session["idKompanija"];
                List<Ogla> oglas = (from o in db.Oglas
                                    where o.IdKompanija == sessionId
                                    select o).ToList();

                return View(oglas);
            }
            else
            {
                int sessionId = (int)Session["idAgentKompanije"];
                List<Ogla> oglas = (from o in db.Oglas
                                    where o.IdKompanija == sessionId
                                    select o).ToList();

                return View(oglas);
            }


        }

        public ActionResult KandidatiOglasa(int? id)
        {
            List<Kandidat> kandidati = (from o in db.Kandidats
                                        where o.idOglas == id
                                        select o).ToList();

            return View(kandidati);
        }

        public FileResult DownloadPopratniDokument(int id)
        {
            var kandidat = db.Kandidats.FirstOrDefault(k => k.idKandidat == id);
            if (kandidat == null)
            {
                return null;
            }

            var fileBytes = System.IO.File.ReadAllBytes(kandidat.propratniDokument);
            var fileName = Path.GetFileName(kandidat.propratniDokument);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public FileResult DownloadCv(int id)
        {
            var kandidat = db.Kandidats.FirstOrDefault(k => k.idKandidat == id);
            if (kandidat == null)
            {
                return null;
            }

            var fileBytes = System.IO.File.ReadAllBytes(kandidat.cv);
            var fileName = Path.GetFileName(kandidat.cv);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        [HttpGet]
        public ActionResult ObjavljivanjeOglasa(string Emp_Dept, string iskustvo, string KategorijaLista)
        {
            var DeptList = new List<string>();
            var DeptQuery = from q in db.Mestoes orderby q.naziv select q.naziv;
            DeptList.AddRange(DeptQuery.Distinct());

            var DeptList2 = new List<string>();
            var DeptQuery2 = from q in db.Iskustvoes orderby q.naziv select q.naziv;
            DeptList2.AddRange(DeptQuery2.Distinct());

            var kategorijaList = new List<string>();
            var kategorijaQuery = from q in db.Kategorijas orderby q.naziv select q.naziv;
            kategorijaList.AddRange(kategorijaQuery.Distinct());

            ViewBag.Kategorija_DropDown = new SelectList(kategorijaList);



            ViewBag.Emp_Data = new SelectList(DeptList);
            ViewBag.Emp_Data2 = new SelectList(DeptList2);


            var voo = new List<VirtualObjavaOglasa>();
            int sessionId = (int)Session["idKompanija"];


            

            foreach(var uplataOglasa in db.UplataOglasas)
            {
                voo.Add(new VirtualObjavaOglasa
                {
                    KLJUCKOMPANIJE = uplataOglasa.idKompanija,
                    idCenovnikUplataOglasa = uplataOglasa.idCenovnikUplataOglasa,
                    oglasi = uplataOglasa.oglasi
                });
            }

            var virtualnaKlasa = voo.Where(o => o.KLJUCKOMPANIJE == sessionId).FirstOrDefault();
            if(virtualnaKlasa != null)
            {
                UplataOglasa uo = db.UplataOglasas.Where(o => o.idKompanija == virtualnaKlasa.KLJUCKOMPANIJE).SingleOrDefault();
                if(uo != null)
                {
                    if (uo.oglasi == 0)
                    {
                        db.UplataOglasas.Remove(uo);
                        db.SaveChanges();
                        return View();
                    }
                    else
                    {
                        return View(virtualnaKlasa);
                    }
                }
                return View(virtualnaKlasa);
            }
            else
            {
                return View();
            }
            

        }

        [HttpPost]
        public ActionResult ObjavljivanjeOglasa(VirtualObjavaOglasa o, string Emp_Dept, string iskustvo, string KategorijaLista)
        {
            int sessionId = (int)Session["idKompanija"];


            Mesto m = db.Mestoes.Where(s => s.naziv == Emp_Dept).SingleOrDefault();
            Iskustvo i = db.Iskustvoes.Where(s => s.naziv == iskustvo).SingleOrDefault();
            Kategorija k = db.Kategorijas.Where(s => s.naziv == KategorijaLista).SingleOrDefault();
            using (db = new Agencija_Context())
            {
                var oglasi = new Ogla()
                {
                    istice = DateTime.Now,
                    IdKompanija = sessionId,
                    naslov = o.naslov,
                    opis = o.opis,
                    idIskustvo = i.idIskustvo,
                    idMesto = m.idMesto,
                    idKategorija = k.idKategorija,
                    poseta = 1
                };
                db.Oglas.Add(oglasi);
                UplataOglasa uo = db.UplataOglasas.Where(iw => iw.idCenovnikUplataOglasa == o.idCenovnikUplataOglasa).SingleOrDefault();
                uo.oglasi -= 1;
                db.SaveChanges();
                TempData["ObjaviOglasi"] = "You added the job ad!";

            }

            return RedirectToAction("ObjavljivanjeOglasa");
            
        }

        [HttpGet]
        public ActionResult KupiOglase()
        {
            List<CenovnikOglasa> cenovnik = (from o in db.CenovnikOglasas
                                             select o).ToList();

            return View(cenovnik);
        }

        [HttpPost]
        public ActionResult KupiOglase([Bind(Prefix = "id")] int id)
        {
            int sessionId = (int)Session["idKompanija"];

            var UplacenOglas = db.UplataOglasas.Where(o => o.idKompanija == sessionId).SingleOrDefault();

            if (UplacenOglas == null)
            {
                var paket = db.CenovnikOglasas.Where(o => o.idCenovnik == id).SingleOrDefault();

                using (db = new Agencija_Context())
                {
                    var uplata = new UplataOglasa
                    {
                        idKompanija = sessionId,
                        idCenovnikOglasa = paket.idCenovnik,
                        cena = paket.cena,
                        oglasi = paket.brojOglasa,
                        datumUplate = DateTime.Now
                    };
                    db.UplataOglasas.Add(uplata);
                    db.SaveChanges();
                    TempData["Oglasi"] = "You successfully purchesed the package.";
                }
                return RedirectToAction("ObjavljivanjeOglasa", TempData["Oglasi"] = "You successfully purchesed the package.");
            }
            else
            {
                ViewBag.Error = "Ne mozete kupiti ponovo paket, dok ne potrosite vec postojeci sto imate!";
                return RedirectToAction("KupiOglase");
            }
        }

    }
}
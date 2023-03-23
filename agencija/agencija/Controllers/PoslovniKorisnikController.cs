using agencija.Models;
using agencija.Models.Funkcije;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class PoslovniKorisnikController : Controller
    {
        PoslovniKorisnik ps = new PoslovniKorisnik();
        Agencija_Context db = new Agencija_Context();
        // GET: PoslovniKorisnik
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public JsonResult GetKategorije()
        //{
        //    db.Configuration.LazyLoadingEnabled = false;
        //    List<Kategorija> k = db.Kategorijas.ToList();
        //    return Json(k, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetMesto()
        //{
        //    db.Configuration.LazyLoadingEnabled = false;
        //    List<Mesto> m = db.Mestoes.ToList();
        //    return Json(m, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetIskustvo()
        //{
        //    db.Configuration.LazyLoadingEnabled = false;
        //    List<Iskustvo> i = db.Iskustvoes.ToList();
        //    return Json(i, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult UnosNovogOglasa()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public JsonResult DodajOglas(string Istice, string Naslov, string Opis, int kategorijaID, int mestoID, int idIskustvo)
        //{
        //    string novOglas = ps.NovOglas(Istice, Naslov, Opis, kategorijaID, mestoID, idIskustvo);
        //    return Json(novOglas);
        //}

        //[HttpGet]
        //public ActionResult OglasiZaPLacanje()
        //{
        //    List<OglasVezaSaKljucevima> oglasiZaPlacanje = ps.OglasiZaPlacanje().ToList();
        //    return View(oglasiZaPlacanje);
        //}
        ////Izmeniti upit za placenje oglase detalje
        //[HttpGet]
        //public ActionResult DetaljiNeplacenogOglasa(int? id)
        //{
        //    OglasVezaSaKljucevima oglasVezaSaKljucevima = ps.OglasiZaPlacanje().Where(o => o.idOglas == id).SingleOrDefault();
        //    return View(oglasVezaSaKljucevima);
        //}
        //[HttpGet]
        //public ActionResult DetaljiObjavljenogOglasa(int? id)
        //{
        //    OglasVezaSaKljucevima detaljiObjavljenog = ps.ObjavljeniOglasi().Where(o => o.idOglas == id).SingleOrDefault();
        //    return View(detaljiObjavljenog);
        //}
        //[HttpGet]
        //public ActionResult ObjavljeniOglasi()
        //{
        //    List<OglasVezaSaKljucevima> objavljeniOglasi = ps.ObjavljeniOglasi().ToList();
        //    return View(objavljeniOglasi);
        //}
        //[HttpGet]
        //public ActionResult IstekliOglasi()
        //{
        //    List<OglasVezaSaKljucevima> istekao = ps.IstekliOglasi();
        //    return View(istekao);
        //}
        //[HttpPost]
        //public ActionResult BrisanjeIsteklogOglasa(int? id)
        //{
        //    if (ps.BrisanjeIsteklogOglasa(id))
        //    {
        //        return RedirectToAction("IstekliOglasi");
        //    }
        //    else
        //    {
        //        return RedirectToAction("IstekliOglasi");
        //    }
        //}

        //public JsonResult PronadjiOglas(int id)
        //{
        //    db.Configuration.LazyLoadingEnabled = false;
        //    Ogla oglas = db.Oglas.Find(id);
        //    return Json(oglas, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult IzmeniOglas(int id, string istice, string naslov, string opis, int kategorijaID, int mestoID, int idIskustvo)
        //{
        //    string izmenaOglasa = ps.IzmenaOglasaValidacija(id, istice, naslov, opis, kategorijaID, mestoID, idIskustvo);
        //    return Json(izmenaOglasa);
        //}

        //[HttpGet]
        //public ActionResult Kandidati(int? id, int page = 1, int pageSize = 3)
        //{
        //    List<KorisnikKandidat> korisnici = ps.Kandidati(id).ToList();
        //    PagedList<KorisnikKandidat> pagedList = new PagedList<KorisnikKandidat>(korisnici, page, pageSize);
        //    return View(pagedList);
        //}
        //public ActionResult DetaljiKandidata(int? id, int? idOglas)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    KorisnikKandidat korisnik = ps.DetaljiKandidata(id, idOglas);
        //    return View(korisnik);
        //}

        ////[HttpGet]
        ////public FileResult GetPdf(int? id)
        ////{
        ////    using (var db = new Agencija_Context())
        ////    {
        ////        Kandidat kandidat = db.Kandidats.Where(x => x.idKandidat == id).SingleOrDefault();
        ////        var pdf = kandidat.fileTypeCV.Substring(12, 3);

        ////        return File(kandidat.cv, "application/pdf");


        ////    }
        ////}
        ////[HttpGet]
        ////public FileResult GetPropratniDokument(int? id, int? idOglas)
        ////{
        ////    using (var db = new Agencija_Context())
        ////    {
        ////        Kandidat kandidat = db.Kandidats.Where(x => x.idUser == id && x.idOglas == idOglas).SingleOrDefault();
        ////        var pdf = kandidat.fileTypePropratniDokument.Substring(12, 3);

        ////        return File(kandidat.propratniDokument, "application/pdf");


        ////    }
        ////}
        ////[HttpPost]
        ////public FileResult DownloadFile(int? idKandidat)
        ////{
        ////    using (var db = new Agencija_Context())
        ////    {
        ////        Kandidat kandidat = db.Kandidats.Where(x => x.idKandidat == idKandidat).SingleOrDefault();
        ////        return File(kandidat.propratniDokument, kandidat.fileTypePropratniDokument);
        ////    }
        ////}

        ////[HttpPost]
        ////public FileResult DownloadFileCV(int? idKandidat)
        ////{
        ////    using (var db = new Agencija_Context())
        ////    {
        ////        Kandidat kandidat = db.Kandidats.Where(x => x.idKandidat == idKandidat).SingleOrDefault();
        ////        return File(kandidat.cv, kandidat.fileTypeCV);
        ////    }
        ////}


        //[HttpPost]
        //public JsonResult SlanjeEmailKandidat(int? id, string Email, string Datum, string Ulica, string Izbor, string EmailKorisnik, string pass)
        //{
        //    string validacijaPodataka = ps.SlanjeEmailKandidat(id, Email, Datum, Ulica, Izbor, EmailKorisnik, pass);
        //    return Json(validacijaPodataka);

        //}

        //public ActionResult SlanjeMejlaPlacanje(int? idOglas)
        //{
        //    Ogla oglas = db.Oglas.Where(x => x.idOglas == idOglas).SingleOrDefault();
        //    return View(oglas);
        //}
        //[HttpPost]
        //public JsonResult SlanjeMejlaPlacanje1(int IdKompanija, string naslov, string email, string Izbor)
        //{
        //    string validacijaPodataka = ps.SlanjeMejlaPlacanje1(IdKompanija, naslov, email, Izbor);
        //    return Json(validacijaPodataka);
        //}
        //[HttpGet]
        //public ActionResult ProfilKompanije(string email = "nesto@gmail.com")
        //{
        //    Kompanija kompanija = ps.Profil(email);
        //    return View(kompanija);
        //}

        //public ActionResult Konkurisi()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Konkurisi1(Kandidat kandidat, HttpPostedFileBase propratniDokument1, HttpPostedFileBase cv1)
        //{
        //    if (propratniDokument1 != null)
        //    {
        //        if (cv1 != null)
        //        {
        //            using (var db = new Agencija_Context())
        //            {
        //                var fileSizePropratni = propratniDokument1.ContentLength;
        //                var fileSizeCV = cv1.ContentLength;
        //                var fileLimit = 0.5 * 1024 * 1024;
        //                if(fileSizePropratni <= fileLimit && fileSizeCV <= fileLimit)
        //                {
        //                    Kandidat k = new Kandidat()
        //                    {
        //                        idOglas = kandidat.idOglas,
        //                        propratniDokument = new byte[fileSizePropratni],
        //                        cv = new byte[cv1.ContentLength],
        //                        idUser = kandidat.idUser
        //                    };
        //                    propratniDokument1.InputStream.Read(k.propratniDokument, 0, fileSizePropratni);
        //                    cv1.InputStream.Read(k.cv, 0, cv1.ContentLength);
        //                    db.Kandidats.Add(k);
        //                    db.SaveChanges();
        //                }

        //            }
        //        }
        //        else
        //        {
        //            using (var db = new Agencija_Context())
        //            {
        //                var fileSizePropratni = propratniDokument1.ContentLength;
        //                var fileLimit = 0.5 * 1024 * 1024;
        //                if (fileSizePropratni <= fileLimit)
        //                {
        //                    Kandidat k = new Kandidat()
        //                    {
        //                        idOglas = kandidat.idOglas,
        //                        propratniDokument = new byte[propratniDokument1.ContentLength],
        //                        idUser = kandidat.idUser
        //                    };
        //                    propratniDokument1.InputStream.Read(k.propratniDokument, 0, propratniDokument1.ContentLength);
        //                    db.Kandidats.Add(k);
        //                    db.SaveChanges();
        //                }

        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (var db = new Agencija_Context())
        //        {

        //                Kandidat k = new Kandidat()
        //                {
        //                    idOglas = kandidat.idOglas,
        //                    idUser = kandidat.idUser
        //                };
        //                db.Kandidats.Add(k);
        //                db.SaveChanges();
        //            }

        //        }
        //    return View("Konkurisi");
        //    }


        //public ActionResult DodajKompaniju()
        //{
        //    return View();
        //}
        //public ActionResult DodajKompaniju1(Kompanija komp, HttpPostedFileBase logo1)
        //{
        //    if (komp.video != null)
        //    {
        //        if (logo1 != null)
        //        {
        //            using (var db = new Agencija_Context())
        //            {
        //                var fileSizeLogo1 = logo1.ContentLength;
        //                var fileLimit = 0.5 * 1024 * 1024;
        //                if (fileSizeLogo1 <= fileLimit)
        //                {

        //                    Kompanija kompanija = new Kompanija()
        //                    {
        //                        video = komp.video,
        //                        sajt = komp.sajt,
        //                        opis = komp.opis,
        //                        naziv = komp.naziv,
        //                        logo = new byte[logo1.ContentLength],
        //                        adresa = komp.adresa,
        //                        telefon = komp.telefon,
        //                        pib = komp.pib
        //                    };

        //                    logo1.InputStream.Read(kompanija.logo, 0, logo1.ContentLength);
        //                    db.Kompanijas.Add(kompanija);
        //                    db.SaveChanges();

        //                }
        //            }
        //        }
        //        else
        //        {
        //            using (var db = new Agencija_Context())
        //            {


        //                Kompanija kompanija = new Kompanija()
        //                {
        //                    video = komp.video,
        //                    sajt = komp.sajt,
        //                    opis = komp.opis,
        //                    naziv = komp.naziv,
        //                    logo = null,
        //                    adresa = komp.adresa,
        //                    telefon = komp.telefon,
        //                    pib = komp.pib
        //                };

        //                db.Kompanijas.Add(kompanija);
        //                db.SaveChanges();
        //            }
        //        }

        //    }
        //    else
        //    {
        //        using (var db = new Agencija_Context())
        //        {


        //            Kompanija kompanija = new Kompanija()
        //            {
        //                video = null,
        //                sajt = komp.sajt,
        //                opis = komp.opis,
        //                naziv = komp.naziv,
        //                logo = null,
        //                adresa = komp.adresa,
        //                telefon = komp.telefon,
        //                pib = komp.pib
        //            };

        //            db.Kompanijas.Add(kompanija);
        //            db.SaveChanges();
        //        }
        //    }
        //    return View("DodajKompaniju");
        //}

        //public ActionResult DodajKorisnika()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DodajKorisnika1(string Ime, string Prezime, string Email, string Telefon, string Username, string Sifra, HttpPostedFileBase slika1, int idRola)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new Agencija_Context())
        //        {
        //            var fileSizeIMG = slika1.ContentLength;
        //            var fileLimit = 0.5 * 1024 * 1024;
        //            if (fileSizeIMG <= fileLimit)
        //            {

        //                Korisnik korisnik1 = new Korisnik()
        //                {
        //                    Ime = Ime,
        //                    Prezime = Prezime,
        //                    Email = Email,
        //                    Telefon = Telefon,
        //                    Username = Username,
        //                    Sifra = Sifra,
        //                    idRola = idRola,
        //                    Slika = new byte[slika1.ContentLength]
        //                };

        //                slika1.InputStream.Read(korisnik1.Slika, 0, slika1.ContentLength);
        //                db.Korisniks.Add(korisnik1);
        //                db.SaveChanges();

        //            }
        //        }
        //    }

        //    return View();
        //}
    }
}
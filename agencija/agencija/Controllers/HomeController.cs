using agencija.Models;
using agencija.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace agencija.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            db = new Agencija_Context();
        
        }



        Agencija_Context db = new Agencija_Context();

        [HttpGet]
        public ActionResult Kompanija()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kompanija(string userEmail, string adresa, int pib, string sajt, string naziv)
        {
            if (ModelState.IsValid)
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress("stefanmajkic00@gmail.com"));
                msg.From = new MailAddress("majkicstefan00@gmail.com");
                msg.Subject = "PRIJAVA KOMPANIJE";
                msg.Body ="Email: "+ userEmail+"<br/>Pib:" + pib + "<br/>Adresa: "
                    + adresa + "<br/>Sajt: " + sajt + "<br/>Naziv:" + naziv;
                msg.IsBodyHtml = true;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                smt.Port = 587;
                smt.UseDefaultCredentials = false;
                smt.Credentials = new NetworkCredential("majkicstefan00@gmail.com", "btlonhutwpdkyroq");
                smt.EnableSsl = true;
                smt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smt.Send(msg);
            }


            return View();
        }

        public ActionResult KompanijaLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KompanijaLogin(Korisnik k)
        {
            using (db = new Agencija_Context())
            {
                var usr = db.Korisniks.SingleOrDefault(u => u.Username == k.Username && u.Sifra == k.Sifra);
                if (usr != null)
                {
                    var kompanija = db.Kompanijas.SingleOrDefault(u => u.IdKompanija == usr.idKompanija);
                    if (usr.idRola == 2)
                    {
                        Session["idKompanija"] = kompanija.IdKompanija;

                        HttpCookie cookie = new HttpCookie("MyCookie");
                        cookie.Value = usr.IdKorisnik.ToString();
                        cookie.Expires = DateTime.Now.AddHours(10);
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Poslodavac", kompanija);
                    }
                    else
                    {
                        Session["idAgentKompanije"] = usr.idKompanija;

                        HttpCookie cookie = new HttpCookie("MyCookie");
                        cookie.Value = usr.IdKorisnik.ToString();
                        cookie.Expires = DateTime.Now.AddHours(10);
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("OglasiKompanija", "Poslodavac");
                    }
                    
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return View(k);
                }
            }
        }


        //public JsonResult Search()
        //{
        //    db = new Agencija_Context();
        //    List<Ogla> oglas = db.Oglas.ToList();

        //    var s = new JavaScriptSerializer();

        //    s.MaxJsonLength = Int32.MaxValue;

        //    string value = string.Empty + s;

        //    value = JsonConvert.SerializeObject(oglas, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });



        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult Konkurisi(int? id)
        {
            int sessionId = (int)Session["idKorisnik"];
            Ogla oglas = db.Oglas.Where(i => i.idOglas == id).SingleOrDefault();
            string cookie = Request.Cookies["MyCookie"].Value;
            Kandidat k = new Kandidat();

            VirtualKandidat vk = new VirtualKandidat();

            vk.idUser = sessionId;
            vk.Korisnik = db.Korisniks.Where(i => i.IdKorisnik == vk.idUser).SingleOrDefault();
            vk.Ogla = oglas;


            ViewBag.idOglas = id;
            ViewBag.idKorisnik = cookie;

            return View(vk);
        }
        [HttpPost]
        public ActionResult Konkurisi(VirtualKandidat k) 
        {
            using(db = new Agencija_Context())
            {
                var kandidat = new Kandidat()
                {
                    idOglas = k.idOglas,
                    idUser = k.idUser,
                    cv = SaveToPhysicalLocation(k.cv),
                    propratniDokument = SaveToPhysicalLocation(k.propratniDokument)
                };
                db.Kandidats.Add(kandidat);
                db.SaveChanges();

                ViewBag.SuccessMessage = "Form submitted successfully.";
            }

            return View(k);
        }

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file != null && file?.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                file.SaveAs(path);
                return path;
            }
            else
            {
                ModelState.AddModelError("file", "Please select a file to upload.");
                return string.Empty;
            }

            
        }


        //[HttpPost]
        //public ActionResult Konkurisi(Kandidat kandidat, HttpPostedFileBase propratniDokument1, HttpPostedFileBase cv1)
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
        //                if (fileSizePropratni <= fileLimit && fileSizeCV <= fileLimit)
        //                {
        //                    Kandidat k = new Kandidat()
        //                    {
        //                        idOglas = kandidat.idOglas,
        //                        propratniDokument = new byte[fileSizePropratni],
        //                        fileTypePropratniDokument = propratniDokument1.ContentType,
        //                        cv = new byte[cv1.ContentLength],
        //                        fileTypeCV = cv1.ContentType,
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
        //                        fileTypePropratniDokument = propratniDokument1.ContentType,
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

        //            Kandidat k = new Kandidat()
        //            {
        //                idOglas = kandidat.idOglas,
        //                idUser = kandidat.idUser
        //            };
        //            db.Kandidats.Add(k);
        //            db.SaveChanges();
        //        }

        //    }
        //    return View("Konkurisi");
        //}






        public ActionResult Index(string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page, int? omiljeniOglasi)
        {


            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 3;
            int pageNumber = (page ?? 1);




            var DeptList = new List<string>();
            var DeptQuery = from q in db.Oglas orderby q.Mesto.naziv select q.Mesto.naziv;
            DeptList.AddRange(DeptQuery.Distinct());

            var DeptList2 = new List<string>();
            var DeptQuery2 = from q in db.Oglas orderby q.Iskustvo.naziv select q.Iskustvo.naziv;
            DeptList2.AddRange(DeptQuery2.Distinct());

            var kategorijaList = new List<string>();
            var kategorijaQuery = from q in db.Kategorijas orderby q.naziv select q.naziv;
            kategorijaList.AddRange(kategorijaQuery.Distinct());

            ViewBag.Kategorija_DropDown = new SelectList(kategorijaList);



            ViewBag.Emp_Data = new SelectList(DeptList);
            ViewBag.Emp_Data2 = new SelectList(DeptList2);

            IList<Ogla> empList = new List<Ogla>();
            var emp = from q in db.Oglas select q;

            if (!String.IsNullOrEmpty(Search_Data))
            {
                emp = emp.Where(s => s.naslov.Contains(Search_Data));
            }



            if (!String.IsNullOrEmpty(Emp_Dept))
            {
                emp = emp.Where(s => s.Mesto.naziv.Contains(Emp_Dept));
            }

            if (!String.IsNullOrEmpty(iskustvo))
            {
                emp = emp.Where(s => s.Iskustvo.naziv.Contains(iskustvo));
            }

            var myEmpList = emp.ToList();

            foreach (var empData in myEmpList)
            {
                empList.Add(new Ogla()
                {
                    idOglas = empData.idOglas,
                    naslov = empData.naslov,
                    opis = empData.opis,
                    Iskustvo = empData.Iskustvo,
                    istice = empData.istice,
                    Kompanija = empData.Kompanija,
                    Kategorija = empData.Kategorija,
                    Mesto = empData.Mesto,
                    omiljen = empData.omiljen
                });
            }

            var viewAds = new List<ViewAdModel>();

            if (Session["idKorisnik"] != null)
            {
                int sessionId = (int)Session["idKorisnik"];


                foreach (var ad in empList)
                {
                    bool isLiked = db.OmiljeniOglasis.Any(l => l.OglasId == ad.idOglas && l.KorisnikId == sessionId);
                    viewAds.Add(new ViewAdModel
                    {
                        AdId = ad.idOglas,
                        IsLiked = isLiked,
                        Title = ad.naslov,
                        Description = ad.opis,
                        Istice = ad.istice,
                        Poseta = ad.poseta,
                        Kategorija = ad.Kategorija,
                        Mesto = ad.Mesto,
                        Iskustvo = ad.Iskustvo,
                        Kompanija = ad.Kompanija
                    });
                }



                return View(viewAds.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                foreach (var ad in empList)
                {
                    bool isLiked = db.OmiljeniOglasis.Any(l => l.OglasId == ad.idOglas);
                    viewAds.Add(new ViewAdModel
                    {
                        AdId = ad.idOglas,
                        Title = ad.naslov,
                        Description = ad.opis,
                        Istice = ad.istice,
                        Poseta = ad.poseta,
                        Kategorija = ad.Kategorija,
                        Mesto = ad.Mesto,
                        Iskustvo = ad.Iskustvo,
                        Kompanija = ad.Kompanija
                    });
                }

                return View(viewAds.ToPagedList(pageNumber, pageSize));
            }

            



        }
        public ActionResult OmiljeniOglasi1(int id)
        {

            using (db = new Agencija_Context())
            {
                OmiljeniOglasi og = db.OmiljeniOglasis.Where(x => x.OglasId == id).FirstOrDefault();

                db.OmiljeniOglasis.Remove(og);
                db.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult OmiljeniOglasi(int? adId)
        {
            int userId = (int)Session["idKorisnik"];
            var likedAd = db.OmiljeniOglasis.FirstOrDefault(a => a.OglasId == adId && a.KorisnikId == userId);

            if (likedAd != null)
            {
                db.OmiljeniOglasis.Remove(likedAd);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                likedAd = new OmiljeniOglasi { OglasId = (int)adId, KorisnikId = userId };
                db.OmiljeniOglasis.Add(likedAd);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
        }

        [HttpPost]
        public ActionResult Like(int adId)
        {
            try
            {
                int userId = (int)Session["idKorisnik"];
                var likedAd = db.OmiljeniOglasis.FirstOrDefault(a => a.OglasId == adId && a.KorisnikId == userId);

                if (likedAd != null)
                {
                    db.OmiljeniOglasis.Remove(likedAd);
                    db.SaveChanges();
                    return Json(new { success = true, isLiked = false });
                }
                else
                {
                    likedAd = new OmiljeniOglasi { OglasId = adId, KorisnikId = userId };
                    db.OmiljeniOglasis.Add(likedAd);
                    db.SaveChanges();
                    return Json(new { success = true, isLiked = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult Remove(int adId)
        {
            try
            {
                int userId = (int)Session["idKorisnik"];
                var likedAd = db.OmiljeniOglasis.FirstOrDefault(a => a.OglasId == adId && a.KorisnikId == userId);

                if (likedAd != null)
                {
                    db.OmiljeniOglasis.Remove(likedAd);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Ad unliked successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Ad is not liked." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        public ActionResult DetaljiOglas(int? id)
        {
            Ogla oglas = db.Oglas.Where(i => i.idOglas == id).SingleOrDefault();
            oglas.poseta += 1;


           

            db.SaveChanges();
            return View(oglas);
        }
    }
}
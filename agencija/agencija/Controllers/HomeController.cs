using agencija.Models;
using agencija.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        
        public ActionResult Konkurisi(int? id)
        { 
            Ogla oglas = db.Oglas.Where(i => i.idOglas == id).SingleOrDefault();
            string cookie = Request.Cookies["MyCookie"].Value;
            Kandidat k = new Kandidat();

            ViewBag.idOglas = id;
            ViewBag.idKorisnik = cookie;

            return View(k);
        }
        [HttpPost]
        public ActionResult Test(Kandidat k) 
        {
            if (!ModelState.IsValid)
            {
                return View(k);
            }

            k.cv = new byte[k.File.InputStream.Length];
            k.File.InputStream.Read(k.cv, 0, k.cv.Length);

            return Content("DetaljiOglas");
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



            return View(empList.ToPagedList(pageNumber, pageSize));
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
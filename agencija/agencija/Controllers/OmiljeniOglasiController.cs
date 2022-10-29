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
        
       
       
        
        public ActionResult UbaciOglas(int? page,int id, string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            if(db.OmiljeniOglasis.Any(x => x.IdOglas < 0))
            {
                

                Ogla oglas = db.Oglas.Find(id);
                oglas.omiljen = 1;
                db.Entry(oglas).State = System.Data.Entity.EntityState.Modified;

                db.OmiljeniOglasis.Add(new OmiljeniOglasi
                {
                    Kolicina = +1,
                    IdOglas = id,
                    Dodat = DateTime.Now,
                    Ogla = oglas
                }); 
                
                db.SaveChanges();
            }
            else
            {
                
               
                if(!db.OmiljeniOglasis.Any(x => x.IdOglas == id)){
                    //lsOglasi.Add(new OmiljeniOglasi(db.Oglas.Find(id)));

                    Ogla oglas = db.Oglas.Find(id);
                    oglas.omiljen = 1;
                    db.Entry(oglas).State = System.Data.Entity.EntityState.Modified;


                    db.OmiljeniOglasis.Add(new OmiljeniOglasi
                    {
                        Kolicina = +1,
                        IdOglas = id,
                        Dodat = DateTime.Now,
                        Ogla = oglas
                    });

                    db.SaveChanges();

                }
                else
                {

                    Ogla oglas = db.Oglas.Find(id);
                    oglas.omiljen = -1;
                    db.Entry(oglas).State = System.Data.Entity.EntityState.Modified;

                    OmiljeniOglasi omiljeni = db.OmiljeniOglasis.Where(x => x.IdOglas == id).SingleOrDefault();
                    db.OmiljeniOglasis.Remove(omiljeni);

                    db.SaveChanges();
                }
            }

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



            return View("~/Views/Home/Index.cshtml", empList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete1(int id)
        {
            using (db = new Agencija_Context())
            {
                OmiljeniOglasi og = db.OmiljeniOglasis.Where(x => x.IdOglas == id).FirstOrDefault();

                db.OmiljeniOglasis.Remove(og);
                db.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Delete(int? id)
        {
            IList<OmiljeniOglasi> omiljeniOglasis = new List<OmiljeniOglasi>();
            var emp = from q in db.OmiljeniOglasis select q;

            var myEmpList = emp.ToList();

           
            
                
                OmiljeniOglasi omiljeni = db.OmiljeniOglasis.Where(x=> x.IdOglas == id).SingleOrDefault();

                db.OmiljeniOglasis.Remove(omiljeni);

                Ogla oglas = db.Oglas.Find(id);
                oglas.omiljen = -1;
                db.Entry(oglas).State = System.Data.Entity.EntityState.Modified;


                db.SaveChanges();

                return RedirectToAction("Index");
            

        }

        

        // GET: OmiljeniOglasi
        public ActionResult Index()
        {
            IList<OmiljeniOglasi> omiljeniOglasis = new List<OmiljeniOglasi>();
            var emp = from q in db.OmiljeniOglasis select q;

            var myEmpList = emp.ToList();

            foreach(var empData in myEmpList)
            {
                omiljeniOglasis.Add(new OmiljeniOglasi
                {
                    Kolicina = empData.Kolicina,
                    IdOmiljeniOglas = empData.IdOmiljeniOglas,
                    IdOglas = empData.IdOglas,
                    Ogla = empData.Ogla,
                    Dodat = empData.Dodat
                });
            }



            return View(omiljeniOglasis.ToList());
        }


    }
}
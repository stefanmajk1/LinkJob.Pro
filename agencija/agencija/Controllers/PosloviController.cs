using agencija.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class PosloviController : Controller
    {
        // GET: Poslovi
        Agencija_Context db = new Agencija_Context();




        public ActionResult Sistem(string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page)
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


            List<Ogla> oglas = (from o in db.Oglas
                                join k in db.Kategorijas
                                on o.idKategorija equals k.idKategorija
                                where k.naziv == "Sistem Administracija"
                                select o).ToList();


            foreach (var empData in oglas)
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
                    Mesto = empData.Mesto

                });
            }

            return View(empList.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Podrska(string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page)
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


            List<Ogla> oglas = (from o in db.Oglas
                                join k in db.Kategorijas
                                on o.idKategorija equals k.idKategorija
                                where k.naziv == "Menadzment"
                                select o).ToList();


            foreach (var empData in oglas)
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
                    Mesto = empData.Mesto

                });
            }


            return View(empList.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Programiranje(string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page)
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


            List<Ogla> oglas = (from o in db.Oglas
                                join k in db.Kategorijas
                                on o.idKategorija equals k.idKategorija
                                where k.naziv == "Programiranje"
                                select o).ToList();


            foreach (var empData in oglas)
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
                    Mesto = empData.Mesto

                });
            }





            return View(empList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult QA(string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page)
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


            List<Ogla> oglas = (from o in db.Oglas
                                join k in db.Kategorijas
                                on o.idKategorija equals k.idKategorija
                                where k.naziv == "QA"
                                select o).ToList();


            foreach (var empData in oglas)
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
                    Mesto = empData.Mesto

                });
            }





            return View(empList.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Index(string link, string KategorijaLista, string Search_Data, string Emp_Dept, string iskustvo, string sortOrder, string currentFilter, string searchString, int? page)
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

            //List<Ogla> oglas = db.Oglas.Where(i => i.Iskustvo.naziv.Contains("Praksa")).ToList();

            List<Ogla> oglas = (from o in db.Oglas
                                join k in db.Kategorijas
                                on o.idKategorija equals k.idKategorija
                                where k.naziv == "Praksa"
                                select o).ToList();


            foreach (var empData in oglas)
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
                    Mesto = empData.Mesto

                });
            }





            return View(empList.ToPagedList(pageNumber, pageSize));
        }
    }
}
using agencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class KompanijaController : Controller
    {
        Agencija_Context db = new Agencija_Context();

        public ActionResult DetaljiKompanije(int? id)
        {
            Kompanija kompanija = db.Kompanijas.Where(i => i.IdKompanija == id).SingleOrDefault();

           

            IList<Kompanija> empListt = new List<Kompanija>();
            var emp1 = from q in db.Kompanijas
                       where q.IdKompanija == id
                       select q;

            var myEmplist2 = emp1.ToList();

            foreach(var empData in myEmplist2)
            {
                empListt.Add(new Kompanija()
                {
                    IdKompanija = empData.IdKompanija,
                    video = empData.video,
                    sajt = empData.sajt,
                    opis = empData.opis,
                    naziv = empData.naziv,
                    logo = empData.logo,
                    adresa = empData.adresa,
                    telefon = empData.telefon,
                    pib = empData.pib,
                    aktivnaKompanija = empData.aktivnaKompanija,
                    Oglas = empData.Oglas
                });
            }

            



            return View(empListt.ToList());
        }

        // GET: Kompanija
        public ActionResult Kompanije(string Search_Data)
        {
            IList<Kompanija> empList = new List<Kompanija>();
            var emp = from q in db.Kompanijas select q;

            if (!String.IsNullOrEmpty(Search_Data))
            {
                emp = emp.Where(s => s.naziv.Contains(Search_Data));
            }

            var myEmpList = emp.ToList();

            foreach (var empData in myEmpList)
            {
                empList.Add(new Kompanija()
                {
                    IdKompanija = empData.IdKompanija,
                    video = empData.video,
                    sajt = empData.sajt,
                    opis = empData.opis,
                    naziv = empData.naziv,
                    logo = empData.logo,
                    adresa = empData.adresa,
                    telefon = empData.telefon,
                    pib = empData.pib
                });
            }

            return View(empList.ToList());
        }
    }
}
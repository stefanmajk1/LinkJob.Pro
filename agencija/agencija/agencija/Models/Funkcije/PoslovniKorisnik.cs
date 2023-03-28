using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace agencija.Models.Funkcije
{
    public class PoslovniKorisnik
    {

        Agencija_Context db = new Agencija_Context();


        //public string NovOglas(string Istice, string Naslov, string Opis, int kategorijaID, int mestoID, int idIskustvo)
        //{
        //    if (!string.IsNullOrEmpty(Istice))
        //    {
        //        if (Convert.ToDateTime(Istice) > System.DateTime.Now)
        //        {
        //            if (!String.IsNullOrEmpty(Naslov))
        //            {
        //                if (Naslov.Length < 50)
        //                {
        //                    if (!String.IsNullOrEmpty(Opis))
        //                    {
        //                        if (Opis.Length < 3000)
        //                        {
        //                            if (kategorijaID > 0)
        //                            {
        //                                if (mestoID > 0)
        //                                {
        //                                    if (idIskustvo > 0)
        //                                    {
        //                                        if (UnosOglasa(Istice, Naslov, Opis, kategorijaID, mestoID, idIskustvo))
        //                                        {
        //                                            return "11";
        //                                        }
        //                                        else
        //                                        {
        //                                            return "10";
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        return "9";
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    return "8";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                return "7";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            return "6";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return "5";
        //                    }
        //                }
        //                else
        //                {
        //                    return "4";
        //                }
        //            }
        //            else
        //            {
        //                return "3";
        //            }
        //        }
        //        else
        //        {
        //            return "2";
        //        }
        //    }
        //    else
        //    {
        //        return "1";
        //    }
        //}
        ////public bool UnosOglasa(string Istice, string Naslov, string Opis, int kategorijaID, int mestoID, int idIskustvo)
        ////{
        ////    var id = (from u in db.Korisniks
        ////              where u.Email.Equals("nesto@gmail.com")
        ////              select u.idKompanija).SingleOrDefault();
        ////    using (var baza = new Agencija_Context())
        ////    {
        ////        Ogla oglas = new Ogla()
        ////        {
        ////            istice = Convert.ToDateTime(Istice),
        ////            naslov = Naslov,
        ////            opis = Opis,
        ////            poseta = 0,
        ////            idKategorija = kategorijaID,
        ////            idMesto = mestoID,
        ////            idIskustvo = idIskustvo,
        ////            IdKompanija = Convert.ToInt32(id)
        ////        };
        ////        baza.Oglas.Add(oglas);
        ////        baza.SaveChanges();
        ////        var idoglas = (from o in db.Oglas
        ////                       orderby o.idOglas descending
        ////                       select o.idOglas).First();
        ////        UplataOglasa uplata = new UplataOglasa()
        ////        {
        ////            idKompanija = Convert.ToInt32(id),
        ////            oglasId = Convert.ToInt32(idoglas),
        ////            cena = 0,
        ////            uplaceno = 0
        ////        };
        ////        baza.UplataOglasas.Add(uplata);
        ////        baza.SaveChanges();
        ////    }
        ////    return true;
        ////}

        //public List<OglasVezaSaKljucevima> OglasiZaPlacanje()
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        try
        //        {
        //            var oglasiZaPlacanje = (from o in db.Oglas
        //                                    join u in db.UplataOglasas
        //                                    on o.idOglas equals u.oglasId
        //                                    join m in db.Mestoes on o.idMesto equals m.idMesto
        //                                    join i in db.Iskustvoes on o.idIskustvo equals i.idIskustvo
        //                                    join kat in db.Kategorijas on o.idKategorija equals kat.idKategorija
        //                                    join komp in db.Kompanijas on o.IdKompanija equals komp.IdKompanija
        //                                    join kor in db.Korisniks on komp.IdKompanija equals kor.idKompanija
        //                                    where kor.Email == "nesto@gmail.com" && u.uplaceno == 0 && o.istice > System.DateTime.Now
        //                                    select new OglasVezaSaKljucevima()
        //                                    {
        //                                        idOglas = o.idOglas,
        //                                        istice = o.istice,
        //                                        naslov = o.naslov,
        //                                        opis = o.opis,
        //                                        poseta = o.poseta,
        //                                        kategorijaID = o.idKategorija,
        //                                        mestoID = o.idMesto,
        //                                        idIskustvo = o.idIskustvo,
        //                                        IdKompanija = o.IdKompanija,
        //                                        Mesto = m,
        //                                        Kategorija = kat,
        //                                        Iskustvo = i,
        //                                        Kompanija = komp,
        //                                        UplataOglasa = u
        //                                    }).ToList();

        //            return oglasiZaPlacanje;
        //        }
        //        catch (Exception) { throw; }
        //    }
        //}
        //public List<OglasVezaSaKljucevima> ObjavljeniOglasi()
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        try
        //        {
        //            var oglasiZaPlacanje = (from o in db.Oglas
        //                                    join u in db.UplataOglasas
        //                                    on o.idOglas equals u.oglasId
        //                                    join m in db.Mestoes on o.idMesto equals m.idMesto
        //                                    join i in db.Iskustvoes on o.idIskustvo equals i.idIskustvo
        //                                    join kat in db.Kategorijas on o.idKategorija equals kat.idKategorija
        //                                    join komp in db.Kompanijas on o.IdKompanija equals komp.IdKompanija
        //                                    join kor in db.Korisniks on komp.IdKompanija equals kor.idKompanija
        //                                    where kor.Email == "nesto@gmail.com" && u.uplaceno == 1 && o.istice >= System.DateTime.Now
        //                                    select new OglasVezaSaKljucevima()
        //                                    {
        //                                        idOglas = o.idOglas,
        //                                        istice = o.istice,
        //                                        naslov = o.naslov,
        //                                        opis = o.opis,
        //                                        poseta = o.poseta,
        //                                        kategorijaID = o.idKategorija,
        //                                        mestoID = o.idMesto,
        //                                        idIskustvo = o.idIskustvo,
        //                                        IdKompanija = o.IdKompanija,
        //                                        Mesto = m,
        //                                        Kategorija = kat,
        //                                        Iskustvo = i,
        //                                        Kompanija = komp,
        //                                        UplataOglasa = u
        //                                    }).ToList();
        //            return oglasiZaPlacanje;
        //        }
        //        catch (Exception) { throw; }
        //    }
        //}
        //public List<OglasVezaSaKljucevima> IstekliOglasi()
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        try
        //        {
        //            var oglasiZaPlacanje = (from o in db.Oglas
        //                                    join u in db.UplataOglasas
        //                                    on o.idOglas equals u.oglasId
        //                                    join m in db.Mestoes on o.idMesto equals m.idMesto
        //                                    join i in db.Iskustvoes on o.idIskustvo equals i.idIskustvo
        //                                    join kat in db.Kategorijas on o.idKategorija equals kat.idKategorija
        //                                    join komp in db.Kompanijas on o.IdKompanija equals komp.IdKompanija
        //                                    join kor in db.Korisniks on komp.IdKompanija equals kor.idKompanija
        //                                    where kor.Email == "nesto@gmail.com" && o.istice < System.DateTime.Now
        //                                    select new OglasVezaSaKljucevima()
        //                                    {
        //                                        idOglas = o.idOglas,
        //                                        istice = o.istice,
        //                                        naslov = o.naslov,
        //                                        opis = o.opis,
        //                                        poseta = o.poseta,
        //                                        kategorijaID = o.idKategorija,
        //                                        mestoID = o.idMesto,
        //                                        idIskustvo = o.idIskustvo,
        //                                        IdKompanija = o.IdKompanija,
        //                                        Mesto = m,
        //                                        Kategorija = kat,
        //                                        Iskustvo = i,
        //                                        Kompanija = komp,
        //                                        UplataOglasa = u
        //                                    }).ToList();
        //            return oglasiZaPlacanje;
        //        }
        //        catch (Exception) { throw; }
        //    }
        //}

        //public bool BrisanjeIsteklogOglasa(int? id)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        if (id != null)
        //        {
        //            Ogla oglas = db.Oglas.Where(o => o.idOglas == id).SingleOrDefault();
        //            UplataOglasa uplataOglasa = db.UplataOglasas.Where(u => u.oglasId == id).SingleOrDefault();
        //            List<Kandidat> kandidat = db.Kandidats.Where(k => k.idOglas == id).ToList();
        //            if (uplataOglasa != null)
        //            {
        //                if (kandidat != null)
        //                {
        //                    db.UplataOglasas.Remove(uplataOglasa);
        //                    db.SaveChanges();
        //                    foreach (var kandidati in kandidat)
        //                    {
        //                        db.Kandidats.Remove(kandidati);
        //                        db.SaveChanges();

        //                    }
        //                    db.Oglas.Remove(oglas);
        //                    db.SaveChanges();
        //                    return true;
        //                }
        //                else
        //                {
        //                    db.UplataOglasas.Remove(uplataOglasa);
        //                    db.SaveChanges();
        //                    db.Oglas.Remove(oglas);
        //                    db.SaveChanges();
        //                    return true;
        //                }
        //            }
        //            else
        //            {
        //                db.Oglas.Remove(oglas);
        //                db.SaveChanges();
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //public string IzmenaOglasaValidacija(int id, string istice, string naslov, string opis, int kategorijaID, int mestoID, int idIskustvo)
        //{
        //    if (!string.IsNullOrEmpty(istice))
        //    {
        //        if (Convert.ToDateTime(istice) > System.DateTime.Now)
        //        {
        //            if (!String.IsNullOrEmpty(naslov))
        //            {
        //                if (naslov.Length < 50)
        //                {
        //                    if (!String.IsNullOrEmpty(opis))
        //                    {
        //                        if (opis.Length < 3000)
        //                        {
        //                            if (IzmenaOglasa(id, istice, naslov, opis, kategorijaID, mestoID, idIskustvo))
        //                            {
        //                                return "Uspeh";
        //                            }
        //                            else
        //                            {
        //                                return "7";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            return "6";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return "5";
        //                    }
        //                }
        //                else
        //                {
        //                    return "4";
        //                }
        //            }
        //            else
        //            {
        //                return "3";
        //            }
        //        }
        //        else
        //        {
        //            return "2";
        //        }
        //    }
        //    else
        //    {
        //        return "1";
        //    }
        //}
        //public bool IzmenaOglasa(int id, string istice, string naslov, string opis, int kategorijaID, int mestoID, int idIskustvo)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        Ogla oglas = db.Oglas.Find(id);
        //        try
        //        {
        //            if (oglas != null)
        //            {
        //                oglas.istice = Convert.ToDateTime(istice);
        //                oglas.naslov = naslov;
        //                oglas.opis = opis;
        //                oglas.idKategorija = kategorijaID;
        //                oglas.idMesto = mestoID;
        //                oglas.idIskustvo = idIskustvo;
        //                db.SaveChanges();
        //                return true;
        //            }
        //            else { return false; }
        //        }
        //        catch (Exception) { return false; }
        //    }
        //}


        //public List<KorisnikKandidat> Kandidati(int? id)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        List<KorisnikKandidat> korisnici = (from k in db.Korisniks
        //                                            join kan in db.Kandidats
        //                                            on k.IdKorisnik equals kan.idUser
        //                                            where kan.idOglas == id
        //                                            select new KorisnikKandidat()
        //                                            {
        //                                                IdKorisnik = k.IdKorisnik,
        //                                                Ime = k.Ime,
        //                                                Prezime = k.Prezime,
        //                                                Email = k.Email,
        //                                                Telefon = k.Telefon,
        //                                                Slika = k.Slika,
        //                                                Kandidat = kan
        //                                            }).ToList();
        //        return korisnici;
        //    }
        //}
        //public KorisnikKandidat DetaljiKandidata(int? id, int? idOglas)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        var kandidat = (from k in db.Korisniks
        //                        join kand in db.Kandidats
        //                        on k.IdKorisnik equals kand.idUser
        //                        where kand.idUser == id && kand.idOglas == idOglas
        //                        select new KorisnikKandidat()
        //                        {
        //                            IdKorisnik = k.IdKorisnik,
        //                            Ime = k.Ime,
        //                            Prezime = k.Prezime,
        //                            Email = k.Email,
        //                            Telefon = k.Telefon,
        //                            Kandidat = kand
        //                        }).SingleOrDefault();
        //        return kandidat;
        //    }
        //}

        //public Korisnik GetKorisnik(int? id)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        Korisnik korisnik = (from k in db.Korisniks
        //                             where k.IdKorisnik == id
        //                             select k).SingleOrDefault();
        //        return korisnik;
        //    }
        //}


        //public string SlanjeEmailKandidat(int? id, string Email, string Datum, string Ulica, string Izbor, string EmailKorisnik, string pass)
        //{
        //    if (!String.IsNullOrEmpty(Datum))
        //    {
        //        if (Convert.ToDateTime(Datum) > System.DateTime.Now)
        //        {
        //            if (!String.IsNullOrEmpty(Ulica))
        //            {
        //                if (!String.IsNullOrEmpty(EmailKorisnik))
        //                {
        //                    if (!String.IsNullOrEmpty(pass))
        //                    {
        //                        try
        //                        {
        //                            // staviti mejl job office tj kompanije sajta
        //                            StringBuilder str = new StringBuilder();
        //                            MailMessage msg = new MailMessage();
        //                            msg.To.Add(new MailAddress(Email));  // replace with valid value 
        //                            msg.From = new MailAddress(EmailKorisnik);  // replace with valid value
        //                            msg.Subject = "Poziv na " + Izbor;
        //                            str.AppendLine("Poštovani, ");
        //                            str.AppendLine();
        //                            str.AppendLine("sa ponosom Vas pozivamo  da dana " + Datum + " u " + Ulica + " dođete na " + Izbor);
        //                            str.AppendLine();
        //                            str.AppendLine("\nS'poštovanjem");
        //                            //msg.Body = "Poštovani, \n sa ponosom Vas pozivamo  da dana " + Datum + " u " + Ulica + " dođete na " + Izbor + "\n\n S'poštovanjem";
        //                            msg.Body = str.ToString();
        //                            msg.IsBodyHtml = true;

        //                            SmtpClient smt = new SmtpClient();
        //                            smt.Host = "smtp.gmail.com";
        //                            smt.Port = 587;
        //                            smt.UseDefaultCredentials = false;
        //                            smt.Credentials = new System.Net.NetworkCredential
        //                                (EmailKorisnik, pass);
        //                            smt.EnableSsl = true;
        //                            smt.DeliveryMethod = SmtpDeliveryMethod.Network;
        //                            smt.Send(msg);
        //                            return "";
        //                        }
        //                        catch
        //                        {
        //                            return "6";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return "5";
        //                    }
        //                }
        //                else
        //                {
        //                    return "4";
        //                }
        //            }
        //            else
        //            {
        //                return "3";
        //            }
        //        }
        //        else
        //        {
        //            return "2";
        //        }
        //    }
        //    else
        //    {
        //        return "1";
        //    }
        //}

        //public string SlanjeMejlaPlacanje1(int IdKompanija, string naslov, string email, string Izbor)
        //{
        //    var podaci = db.Kompanijas.Find(IdKompanija);
        //    string validacijaEmail = @"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$";
        //    Regex provera = new Regex(validacijaEmail);
        //    if (!string.IsNullOrEmpty(email))
        //    {
        //        if (provera.IsMatch(email))
        //        {
        //            try
        //            {
        //                StringBuilder str = new StringBuilder();
        //                MailMessage msg = new MailMessage();
        //                msg.To.Add(new MailAddress(email));  // replace with valid value 
        //                msg.From = new MailAddress("ana.cvejic@gmail.com");  // replace with valid value
        //                msg.Subject = "Plaćanje oglasa " + naslov;
        //                str.AppendLine("Poštovani, ");
        //                str.AppendLine();
        //                str.AppendLine("uplatu oglasa možete izvršiti popunjavanjem uplatnice, instrukcije su sledeće: ");
        //                str.AppendLine();
        //                str.AppendLine("Uplatilac " + podaci.naziv + " " + podaci.adresa);
        //                str.AppendLine();
        //                str.AppendLine("Svrha uplate: ");
        //                str.AppendLine("Uplata za oglas: " + naslov);
        //                str.AppendLine("Primalac: ");
        //                str.AppendLine("Link.JobPro");
        //                str.AppendLine("Iznos: " + Izbor);
        //                str.AppendLine("Račun broj:  165-12348912333-90");
        //                str.AppendLine("\n\n");
        //                str.AppendLine("S'poštovanjem");

        //                //msg.Body = "Poštovani, \n sa ponosom Vas pozivamo  da dana " + Datum + " u " + Ulica + " dođete na " + Izbor + "\n\n S'poštovanjem";
        //                msg.Body = str.ToString();
        //                msg.IsBodyHtml = true;

        //                SmtpClient smt = new SmtpClient();
        //                smt.Host = "smtp.gmail.com";
        //                smt.Port = 587;
        //                smt.UseDefaultCredentials = false;
        //                smt.Credentials = new System.Net.NetworkCredential
        //                    ("ana.cvejic@gmail.com", "anasoftverinzenjer85");
        //                smt.EnableSsl = true;
        //                smt.DeliveryMethod = SmtpDeliveryMethod.Network;
        //                smt.Send(msg);
        //                return "";
        //            }
        //            catch
        //            {
        //                return "3";
        //            }
        //        }
        //        else
        //        {
        //            return "2";
        //        }
        //    }
        //    else
        //    {
        //        return "1";
        //    }
        //}

        //public Kompanija Profil(string email)
        //{
        //    using (var db = new Agencija_Context())
        //    {
        //        Kompanija kompanija = (from k in db.Kompanijas
        //                               join kor in db.Korisniks
        //                               on k.IdKompanija equals kor.idKompanija
        //                               where kor.Email == email
        //                               select k).SingleOrDefault();

        //        return kompanija;
        //    }
        //}

    }
}
    

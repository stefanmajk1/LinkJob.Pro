using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult O_Nama()
        {


            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string ime, string email, string poruka)
        {
            if (ModelState.IsValid)
            {

                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress("milaobradovic2000@gmail.com"));  // replace with valid value 
                msg.From = new MailAddress("mila0919@its.edu.rs");  // replace with valid value
                msg.Subject = "Nova poruka od " + ime;
                msg.Body = "Ime: " + ime + "\n" + "Email:" + email + "\nPoruka:" + poruka;
                msg.IsBodyHtml = true;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                smt.Port = 587;
                smt.UseDefaultCredentials = false;
                smt.Credentials = new System.Net.NetworkCredential
                    ("mila0919@its.edu.rs", "mila0919@its.edu.rs");
                smt.EnableSsl = true;
                smt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smt.Send(msg);
            }
            return View("Contact");
        }
    }
}
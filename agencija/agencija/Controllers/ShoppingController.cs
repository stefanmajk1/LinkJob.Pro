using agencija.Models;
using agencija.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agencija.Controllers
{
    public class ShoppingController : Controller
    {
        Agencija_Context db;
        List<ShoppingCartModel> listShoppingCartModels;
        public ShoppingController()
        {
            db = new Agencija_Context();
            listShoppingCartModels = new List<ShoppingCartModel>();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listOfShoppingViewModels = (from objItem in db.Oglas
                                                                       select new ShoppingViewModel{
                                                                       idOglas = objItem.idOglas,
                                                                        Istice = objItem.istice,
                                                                      Naslov = objItem.naslov,
                                                                       Opis = objItem.opis,
                                                                       Mesto = objItem.Mesto.naziv,
                                                                       Iskustvo = objItem.Iskustvo.naziv,
                                                                       Kompanija = objItem.Kompanija.naziv,
                                                                       Kategorija = objItem.Kategorija.naziv
                                                                       }).ToList();

            return View(listOfShoppingViewModels);

        }

        
        public JsonResult Index(int itemID)
        {
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
            Ogla objItem = db.Oglas.Single(model => model.idOglas == itemID);

            if(Session["CartCounter"] != null)
            {
                listShoppingCartModels = Session["CartItem"] as List<ShoppingCartModel>;
            }
            if(listShoppingCartModels.Any(model => model.idOglas == itemID))
            {
                objShoppingCartModel = listShoppingCartModels.Single(model => model.idOglas == itemID);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
            }
            else
            {
                objShoppingCartModel.idOglas = itemID;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Naslov = objItem.naslov;
                objShoppingCartModel.Opis = objItem.opis;
                objShoppingCartModel.Istice = objItem.istice;
                objShoppingCartModel.Mesto = objItem.Mesto.naziv;
                objShoppingCartModel.Iskustvo = objItem.Iskustvo.naziv;
                objShoppingCartModel.Kompanija = objItem.Kompanija.naziv;
                objShoppingCartModel.Kategorija = objItem.Kategorija.naziv;
                listShoppingCartModels.Add(objShoppingCartModel);
            }
            Session["CartCounter"] = listShoppingCartModels.Count;
            Session["CartItem"] = listShoppingCartModels;

            return Json(data: new { Success = true, Counter = listShoppingCartModels.Count}, JsonRequestBehavior.AllowGet);
        }
    }
}
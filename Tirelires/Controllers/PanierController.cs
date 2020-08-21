using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tirelires.Controllers
{
    public class PanierController : Controller
    {
        // GET: PanierController
        public ActionResult Index()
        {
            Commande panierActuel = new Commande();
            if (HttpContext.Session.GetString("panier") != null)
            {
                panierActuel = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));
            }
            string strPanierActuel = JsonConvert.SerializeObject(panierActuel);
            HttpContext.Session.SetString("panier", strPanierActuel);
            return View(strPanierActuel);
        }
    }
}

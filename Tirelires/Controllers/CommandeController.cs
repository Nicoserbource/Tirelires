using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tirelires.Repositories;

namespace Tirelires.Controllers
{
    public class CommandeController : Controller
    {
        private TireliresContext _context;
        private IRepository<Produit> _repository;

        public CommandeController(IWebHostEnvironment env)
        {
            _context = new TireliresContext();
            _repository = new Repository<Produit>(_context);
        }

        // GET: PanierController
        public IActionResult Index()
        {
            if(ModelState.IsValid)
            {
                if(User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Session.GetString("panier") != null)
                    {
                        Commande panierActuel = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));
                        foreach(DetailCommande detail in panierActuel.DetailCommande)
                        {
                            detail.IdProduitNavigation = _repository.Get(detail.IdProduit);
                        }
                        return View(panierActuel.DetailCommande);
                    }
                }
                return RedirectToAction("Login", "Compte", new { area = "" });
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

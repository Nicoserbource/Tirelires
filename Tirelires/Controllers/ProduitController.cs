using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Tirelires.Data;
using Tirelires.Repositories;

namespace Tirelires.Controllers
{
    public class ProduitController : Controller
    {
        private TireliresContext _context;
        private IRepository<Produit> _repository;
        private IWebHostEnvironment _environment;

        public ProduitController(IWebHostEnvironment env)
        {
            _context = new TireliresContext();
            _repository = new Repository<Produit>(_context);
            _environment = env;
        }

        // GET: ProduitController
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public ActionResult Gallery()
        {
            return View(_repository.GetAll());
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.Get(id));
        }

        // GET: ProduitController/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            //Liste de sélection des couleurs
            ViewBag.Couleur = (new Repository<Couleur>(_context)).GetAll().Select(
                c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }
            );
            //Liste de sélection des fabricants
            ViewBag.Fabricant = (new Repository<Fabricant>(_context)).GetAll().Select(
                f => new SelectListItem { Text = f.Nom, Value = f.Id.ToString() }
            );
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit)
        {
            try
            {
                _repository.Create(produit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(int id)
        {
            //Liste de sélection des couleurs
            ViewBag.Couleur = (new Repository<Couleur>(_context)).GetAll().Select(
                c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }
            );
            //Liste de sélection des fabricants
            ViewBag.Fabricant = (new Repository<Fabricant>(_context)).GetAll().Select(
                f => new SelectListItem { Text = f.Nom, Value = f.Id.ToString() }
            );
            return View(_repository.Get(id));
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produit produit)
        {
            try
            {
                _repository.Edit(produit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit produit)
        {
            try
            {
                _repository.Delete(produit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public void Order(int id, int qte)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Claim claim = User.Claims.ToList().FirstOrDefault();
                    string userId = claim.Value;

                    if (userId != null)
                    {
                        if (HttpContext.Session.GetString("panier") == null)
                        {
                            Commande panier = new Commande();
                            panier.IdClient = userId;
                            panier.Date = DateTime.Today;
                            panier.IdStatut = 1;
                            string strPanier = JsonConvert.SerializeObject(panier);
                            HttpContext.Session.SetString("panier", strPanier);
                        }
                        Commande panierActuel = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));

                        DetailCommande detail = panierActuel.DetailCommande.Where(d => d.IdProduit == id).FirstOrDefault();

                        if (detail == null)
                        {
                            detail = new DetailCommande()
                            {
                                IdCommande = panierActuel.Id,
                                IdProduit = id,
                                Quantite = qte,
                                PrixUnitaire = _repository.Get(id).Prix
                            };
                            panierActuel.DetailCommande.Add(detail);
                        }
                        else
                        {
                            detail.Quantite += qte;
                        }
                        string strPanierActuel = JsonConvert.SerializeObject(panierActuel);
                        HttpContext.Session.SetString("panier", strPanierActuel);
                    }
                }
            }
        }

        [Authorize]
        public ContentResult RemoveFromShoppingCard(int id)
        {
            Claim claim = User.Claims.ToList().FirstOrDefault();
            string userId = claim.Value;

            if (HttpContext.Session.GetString("panier") != null)
            {
                DetailCommande detail;
                Commande panierActuel = JsonConvert.DeserializeObject<Commande>(HttpContext.Session.GetString("panier"));

                detail = panierActuel.DetailCommande.Where(d => d.IdProduit == id).First();
                detail.Quantite = (detail.Quantite > 0) ? detail.Quantite - 1 : 0;

                string strPanierActuel = JsonConvert.SerializeObject(panierActuel);
                HttpContext.Session.SetString("panier", strPanierActuel);
                return Content(detail.Quantite.ToString());
            }
            else return Content("");
        }

        public IActionResult GetImage(int id)
        {
            Produit produit = _repository.Get(id);
            if (produit != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\img\\";
                string img = produit.Image.OrderByDescending(i => i.Chemin).Select(i => i.Chemin).SingleOrDefault();
                Image photo = produit.Image.SingleOrDefault();
                string fullPath = webRootpath + folderPath + img;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    var provider = new FileExtensionContentTypeProvider();
                    string contentType;
                    if (!provider.TryGetContentType(fullPath, out contentType))
                    {
                        contentType = "application/octet-stream";
                    }
                    return File(fileBytes, contentType);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tirelires.Repositories;

namespace Tirelires.Controllers
{
    public class CouleurController : Controller
    {
        private TireliresContext _context;
        private IRepository<Couleur> _repository;

        public CouleurController()
        {
            _context = new TireliresContext();
            _repository = new Repository<Couleur>(_context);
        }

        // GET: CouleurController
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: CouleurController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.Get(id));
        }

        // GET: CouleurController/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouleurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Couleur couleur)
        {
            try
            {
                _repository.Create(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: CouleurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Couleur couleur)
        {
            try
            {
                _repository.Edit(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouleurController/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: CouleurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Couleur couleur)
        {
            try
            {
                _repository.Delete(couleur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

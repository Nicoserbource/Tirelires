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
    public class FabricantController : Controller
    {
        private TireliresContext _context;
        private IRepository<Fabricant> _repository;

        public FabricantController()
        {
            _context = new TireliresContext();
            _repository = new Repository<Fabricant>(_context);
        }

        // GET: FabricantController
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: FabricantController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.Get(id));
        }

        // GET: FabricantController/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricant fabricant)
        {
            try
            {
                _repository.Create(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FabricantController/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: FabricantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Fabricant fabricant)
        {
            try
            {
                _repository.Edit(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FabricantController/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: FabricantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Fabricant fabricant)
        {
            try
            {
                _repository.Delete(fabricant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

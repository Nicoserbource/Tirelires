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
    public class ClientController : Controller
    {
        private IRepository<Client> _repository;

        public ClientController(IRepository<Client> repo)
        {
            _repository = repo;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(string id)
        {
            return View(_repository.Get(id));
        }

        // GET: ClientController/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                _repository.Create(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(string id)
        {
            return View(_repository.Get(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Client client)
        {
            try
            {
                _repository.Edit(client);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(string id)
        {
            return View(_repository.Get(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Client client)
        {
            try
            {
                _repository.Delete(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

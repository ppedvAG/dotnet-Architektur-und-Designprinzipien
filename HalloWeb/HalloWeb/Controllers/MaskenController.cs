using HalloWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HalloWeb.Controllers
{
    public class MaskenController : Controller
    {
        DataManager db = new DataManager();

        // GET: Default
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View(db.GetById(id));
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View(new Maske() { Hersteller = "NEU", Datum = DateTime.Now });
        }

        // POST: Default/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maske maske)
        {
            try
            {
                db.Add(maske);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.GetById(id));
        }

        // POST: Default/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Maske maske)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(maske);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.GetById(id));

        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Maske maske)
        {
            try
            {
                db.Delete(maske);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
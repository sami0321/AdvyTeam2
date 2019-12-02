using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain;
using Service;

namespace Web.Controllers
{
    public class fichemetiersController : Controller
    {
        public FicheMetierService fms = new FicheMetierService();
        public EmployeService es = new  EmployeService();

        // GET: fichemetiers
        public ActionResult Index()
        {
            //var fichemetier = db.fichemetier.Include(f => f.employee1);
            return View(fms.GetAll());
        }

        // GET: fichemetiers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fms.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            return View(fichemetier);
        }

        // GET: fichemetiers/Create
        public ActionResult Create()
        {
            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View();
        }

        // POST: fichemetiers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_f,description_f,F_Famille_Competence,nom_f,Employee_U_ID")] fichemetier fichemetier)
        {

            if (ModelState.IsValid)
            {
                fms.Add(fichemetier);
                fms.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", fichemetier.Employee_U_ID);
            return View(fichemetier);
        }

        // GET: fichemetiers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fms.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", fichemetier.Employee_U_ID);
            return View(fichemetier);
        }

        // POST: fichemetiers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_f,description_f,F_Famille_Competence,nom_f,Employee_U_ID")] fichemetier fichemetier)
        {
            if (ModelState.IsValid)
            {
                fichemetier fm = new fichemetier()
                {
                    id_f = fichemetier.id_f,
                    description_f = fichemetier.description_f,
                    F_Famille_Competence = fichemetier.F_Famille_Competence,
                   // Employee_U_ID = fichemetier.Employee_U_ID
                };
                fms.Update(fm);
                fms.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", fichemetier.Employee_U_ID);
            return View(fichemetier);
        }

        // GET: fichemetiers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fichemetier fichemetier = fms.GetById(id);
            if (fichemetier == null)
            {
                return HttpNotFound();
            }
            return View(fichemetier);
        }

        // POST: fichemetiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fichemetier fichemetier = fms.GetById(id);
            fms.Delete(fichemetier);
            fms.Commit();
            return RedirectToAction("Index");
        }

      



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

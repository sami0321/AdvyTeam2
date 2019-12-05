using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI4GL2.Domain;
using PI4GL2.Service;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FormationsController : Controller
    {


        FormationService fs = new FormationService();
        // GET: Formations
        [Authorize]
        public ActionResult Index()
        {
            return View(fs.GetMany(d=> d.employee_id == int.Parse(HttpContext.User.Identity.Name)));
        }

        // GET: Formations/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            formation formation = fs.GetById(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: Formations/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,etablissement,nom,skill,type")] formation formation)
        {
            if (ModelState.IsValid)
            {
                formation.employee_id = int.Parse(HttpContext.User.Identity.Name);
                fs.Add(formation);
                fs.Commit();
                return RedirectToAction("Index");
            }

            return View(formation);
        }

        // GET: Formations/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            formation formation = fs.GetById(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,etablissement,nom,skill,type")] formation formation)
        {
            if (ModelState.IsValid)
            {
                formation.employee_id = int.Parse(HttpContext.User.Identity.Name);
                fs.Update(formation);
                fs.Commit();
                return RedirectToAction("Index");
            }
            return View(formation);
        }

        // GET: Formations/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {

            formation formation = fs.GetById(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            formation formation = fs.GetById(id);
            fs.Delete(formation);
            fs.Commit();
            return RedirectToAction("Index");
        }
    }
}

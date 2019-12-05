using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class MissionController : Controller
    {
        public IMission ms = new MissionService();
        public EmployeService es = new EmployeService();

        // GET: Mission
        public ActionResult Index(string filtre)
        {
            var list = ms.GetMany();//GetFichemetiers("Developpement");

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.M_TITLE.ToLower().Contains(filtre.ToLower())).ToList(); }
            return View(list);
        }

        // GET: Mission/Details/5
        public ActionResult Details(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            mission m = ms.GetById(id);
            MissionModel M1 = new MissionModel()
            {
                M_TITLE = m.M_TITLE,
                notes = m.notes,
                M_DESCRIPTION = m.M_DESCRIPTION,
                DATE_DEB = m.DATE_DEB,
                DATE_FIN = m.DATE_FIN,
                manager_U_ID = m.manager_U_ID,


            };
            if (m == null)
                return HttpNotFound();

            return View(M1);
        }

        // GET: Mission/Create
        public ActionResult Create()
        {
            ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View();
        }

        // POST: Mission/Create
        [HttpPost]
        public ActionResult Create(MissionModel m)
        {
            mission miss = new mission()
            {
                M_TITLE = m.M_TITLE,
                notes = m.notes,
                M_DESCRIPTION = m.M_DESCRIPTION,
                DATE_DEB = m.DATE_DEB,
                DATE_FIN = m.DATE_FIN,
                manager_U_ID = m.manager_U_ID,


            };
            ms.Add(miss);
            ms.Commit();

            ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", miss.manager_U_ID);
            return RedirectToAction("Index");
        }

        // GET: Mission/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            mission m = ms.GetById(id);
            MissionModel M1 = new MissionModel()
            {
                M_TITLE = m.M_TITLE,
                notes = m.notes,
                M_DESCRIPTION = m.M_DESCRIPTION,
                DATE_DEB = m.DATE_DEB,
                DATE_FIN = m.DATE_FIN,
                manager_U_ID = m.manager_U_ID,


            };
            if (m == null)
                return HttpNotFound();

            ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View(M1);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MissionModel m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    mission p = ms.GetById(id);

                    p.M_TITLE = m.M_TITLE;
                    p.notes = m.notes;
                    p.M_DESCRIPTION = m.M_DESCRIPTION;
                    p.DATE_DEB = m.DATE_DEB;
                    p.DATE_FIN = m.DATE_FIN;
                    p.manager_U_ID = m.manager_U_ID;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    ms.Update(p);
                    ms.Commit();
                    // Service.Dispose();
                    ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", p.manager_U_ID);
                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(m);

            }
            catch
            {
                return View();
            }
        }

        // GET: Mission/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            mission m = ms.GetById(id);
            MissionModel m1 = new MissionModel()
            {
                M_TITLE = m.M_TITLE,
                notes = m.notes,
                M_DESCRIPTION = m.M_DESCRIPTION,
                DATE_DEB = m.DATE_DEB,
                DATE_FIN = m.DATE_FIN,
                manager_U_ID = m.manager_U_ID,


            };
            if (m == null)
                return HttpNotFound();

            return View(m1);
        }

        // POST: Mission/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MissionModel m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    mission p = ms.GetById(id);

                    p.M_TITLE = m.M_TITLE;
                    p.notes = m.notes;
                    p.M_DESCRIPTION = m.M_DESCRIPTION;
                    p.DATE_DEB = m.DATE_DEB;
                    p.DATE_FIN = m.DATE_FIN;
                    p.manager_U_ID = m.manager_U_ID;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("deleeeeeeeeeeeeeeeeete");
                    ms.Delete(p);
                    ms.Commit();
                    // Service.Dispose();
                    ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", p.manager_U_ID);
                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(m);
            }
            catch
            {
                return View();
            }
        }
    }
}

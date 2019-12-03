

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
    public class NoteController : Controller
    {
        INoteService Service = null;
        public NoteController()
        {
            Service = new NoteService();
        }
        // GET: Note
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: Note/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            note p = Service.GetById(id);
            NoteModel p1 = new NoteModel()
            {
                D_STATE = p.D_STATE,
                N_TOTAL = p.N_TOTAL,
                employee_U_ID = p.employee_U_ID,
                mission_M_ID = p.mission_M_ID,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // GET: Note/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        public ActionResult Create(NoteModel note)
        {
            note noteDomain = new note()
            {

                D_STATE = note.D_STATE,
                N_TOTAL = note.N_TOTAL,
                employee_U_ID = note.employee_U_ID,
                mission_M_ID = note.mission_M_ID,



            };
            Service.Add(noteDomain);
            Service.Commit();
            //Service.Dispose();
            return RedirectToAction("Index");
        }

        // GET: Note/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            note p = Service.GetById(id);
            NoteModel p1 = new NoteModel()
            {
                D_STATE = p.D_STATE,
                N_TOTAL = p.N_TOTAL,
                employee_U_ID = p.employee_U_ID,
                mission_M_ID = p.mission_M_ID,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // POST: Note/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NoteModel notem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    note p = Service.GetById(id);

                    p.D_STATE = notem.D_STATE;
                    p.N_TOTAL = notem.N_TOTAL;
                    p.employee_U_ID = notem.employee_U_ID;
                    p.mission_M_ID = notem.mission_M_ID;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    Service.Update(p);
                    Service.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(notem);

            }
            catch
            {
                return View();
            }
        }

        // GET: Note/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            note p = Service.GetById(id);
            NoteModel p1 = new NoteModel()
            {
                D_STATE = p.D_STATE,
                N_TOTAL = p.N_TOTAL,
                employee_U_ID = p.employee_U_ID,
                mission_M_ID = p.mission_M_ID,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // POST: Note/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NoteModel notem)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    note p = Service.GetById(id);
                    notem = new NoteModel()
                    {
                        D_STATE = p.D_STATE,
                        N_TOTAL = p.N_TOTAL,
                        employee_U_ID = p.employee_U_ID,
                        mission_M_ID = p.mission_M_ID,

                    };
                    if (p == null)
                        return HttpNotFound();
                    Console.WriteLine("deletedddddddddddddddddddddddddddddddd");
                    Service.Delete(p);
                    Service.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(notem);

            }
            catch
            {
                return View();
            }
        }
    }
}

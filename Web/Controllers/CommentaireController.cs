using Domaine;
using ExamenWeb.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class CommentaireController : Controller
    {

        CommentaireService cs;
         EmployeeService es;

        public CommentaireController()
        {
            cs = new CommentaireService();

        }


        // GET: Commentaire
        public ActionResult Index()
        {
            return View(cs.GetAll());
        }

        // GET: Commentaire/Details/5
        public ActionResult Details(int id)
        {
                        return View(cs.GetById(id));
        }

        // GET: Commentaire/Create
        public ActionResult Create()
        {
            es = new EmployeeService();
            var employees = es.GetAll();
            ViewBag.employ_U_ID = new SelectList(employees, "U_ID", "U_FirstName");
            return View();
        }

        // POST: Commentaire/Create
        [HttpPost]
        public ActionResult Create(CommentaireViewModels cvm , int arg)
        {

            commentaires c = new commentaires();
            c.note = cvm.note;
            c.text = cvm.text;
            c.employ_U_ID = arg;
            
            cs.Add(c);
            cs.Commit();

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commentaire/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            commentaires p = cs.GetById(id);
            CommentaireViewModels p1 = new CommentaireViewModels()
            {
                note = p.note,
            text = p.text,
            employ_U_ID = p.employ_U_ID


        };
            if (p == null)
                return HttpNotFound();

            return View(p1);

        }

        // POST: Commentaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentaireViewModels c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    commentaires p = cs.GetById(id);

                    p.note = c.note;
                    p.text = c.text;
                    p.employ_U_ID = c.employ_U_ID;
                    // p.Employee_U_ID = f.Employee_U_ID;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    cs.Update(p);
                    cs.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(c);

            }
            catch
            {
                return View();
            }
        }

        // GET: Commentaire/Delete/5
        public ActionResult Delete(int id)
        {
            commentaires c = cs.GetById(id);


            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Commentaire/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, commentaires c)
        {
            try
            {
                // TODO: Add delete logic here
                c = cs.GetById(id);
                cs.Delete(c);
                cs.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

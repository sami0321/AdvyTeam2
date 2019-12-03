using Domaine;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class Eval360Controller : Controller
    {
        
        Eval360Service ev;
        CommentaireService cs;
        public Eval360Controller()
        {
            ev = new Eval360Service();
        }
       
        // GET: Eval360
        public ActionResult Index()
        {
      

            return View(ev.GetAll());
        }
        
       
        // GET: Eval360/Details/5
        public ActionResult Details(int id)
        {
            cs = new CommentaireService();
            eval360 eval = new eval360();
            eval = ev.GetById(id);
            
            ViewBag.Emp = ev.GetById(id);
            ViewBag.Comments = cs.GetMany(e => e.employ_U_ID== eval.emp_U_ID);
            return View();

        }


        public ActionResult evaluer(int id )
        {
            cs = new CommentaireService();
            eval360 eval = new eval360();
            eval = ev.GetById(id);
            return RedirectToAction("../Commentaire/Create", "CommentaireController", new { arg = eval.emp_U_ID });
        }

        // GET: Eval360/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eval360/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: Eval360/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Eval360/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Eval360/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Eval360/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

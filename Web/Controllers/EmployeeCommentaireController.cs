using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class EmployeeCommentaireController : Controller
    {


        CommentaireService cs;
        Eval360Service es;

        public EmployeeCommentaireController()
        {
            cs = new CommentaireService();


        }


        // GET: EmployeeCommentaire
        public ActionResult Index()
        {
          
                ViewBag.Blog = es.GetAll();
                ViewBag.Comments = cs.GetById(5);
                return View();
            
        }

        // GET: EmployeeCommentaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeCommentaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeCommentaire/Create
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

        // GET: EmployeeCommentaire/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeCommentaire/Edit/5
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

        // GET: EmployeeCommentaire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeCommentaire/Delete/5
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

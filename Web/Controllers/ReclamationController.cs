using Domaine;
using ExamenWeb.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class ReclamationController : Controller
    {
        EmployeeService es;
        // GET: Reclamation
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Main-web/rest/reclamations").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<reclamation>>().Result;
            }
            else
                ViewBag.result = "Erreur";

            return View();
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(reclamation r )
        {

          //  employee e = new employee();
            //e=es.GetById(6);
            r.employe_U_ID = null;
        //    r.etat = "NonTraité";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.PostAsJsonAsync<reclamation>("Main-web/rest/reclamations", r).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reclamation/Edit/5
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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
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

using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web.Models;

namespace Web.Controllers
{
    public class CompetenceController : Controller
    {
        // GET: Competence
        public ActionResult Index()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("http://localhost:9080/Main-web/api/competence").Result;
            string res = "";
            using (HttpContent content = response.Content)
            {
                string result = content.ReadAsStringAsync().Result;
                res = result;
            }


            return View(JsonConvert.DeserializeObject<IEnumerable<CompetenceModel>>(res));
        }

        // GET: Competence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Competence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competence/Create
        [HttpPost]
        public ActionResult Create(CompetenceModel q)
        {

            //m.date = DateTime.Today;
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post
                , "http://localhost:9080/Main-web/api/competence");
            string json = new JavaScriptSerializer().Serialize(new
            {

                description = q.descriptionc,
                famille = q.Famille,
                niveau = q.niveau,
                nom = q.nomc,
                metier = q.metier,
            }
                );
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();

            return RedirectToAction("Index");

        }
        
    

        

        // GET: Competence/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Competence/Edit/5
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

        // GET: Competence/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Competence/Delete/5
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

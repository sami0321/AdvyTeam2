using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Security;
using PI4GL2.Service;
using PI4GL2.Domain;
namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {

        const string URL = "http://localhost:9080/Main-web/";
        // GET: Employees
     
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                IEnumerable<Employee> emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                
                return View(emp);
            }
            else
            {
                ViewBag.result = new List<Employee>();
            }
            return View();
        }


        
        public ActionResult IndexAdmin()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                IEnumerable<Employee> emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return View(emp);
            }
            else
            {
                ViewBag.result = new List<Employee>();
            }
            return View();
        }


        public ActionResult Profile()
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/1").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<Employee>().Result;
                HttpResponseMessage response2 = Client.GetAsync("API/Formation/score/1").Result;
                ViewBag.score = response2.Content.ReadAsAsync<Int16>().Result;
                IEnumerable<Employee> emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return View(emp);
            }
            else
            {
                ViewBag.result = new List<Employee>();
            }
            return View();
        }

        [HttpPost]
        public ActionResult IndexAdmin(String recherche)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/perNom/" + recherche).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                IEnumerable<Employee> emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return View(emp);
            }
            else
            {
                ViewBag.result = new List<Employee>();
            }
            return View();
        }



        public ActionResult Accept(int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/accept/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                IEnumerable<Employee> emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.result = new List<Employee>();
            }
            return RedirectToAction("IndexAdmin");
        }

        // GET: Employees/Details/5
        
        public ActionResult Details(int? id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Employee emp = response.Content.ReadAsAsync<Employee>().Result;
                ViewBag.employee = emp;
                return View(emp);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cin,email,firstName,lastName,password,phonenumber,role,salaire")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:9080/Main-web/");
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                HttpResponseMessage response = Client.PostAsync<Employee>("API/Employee", employee, formatter).Result.EnsureSuccessStatusCode();
                Console.WriteLine();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Employee emp = response.Content.ReadAsAsync<Employee>().Result;
                ViewBag.employee = emp;
                return View(emp);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Employees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,cin,email,firstName,lastName,password,phonenumber,role,salaire")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri(URL);
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                HttpResponseMessage response = Client.PutAsync<Employee>("API/Employee/" + employee.id, employee, formatter).Result.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("API/Employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Employee emp = response.Content.ReadAsAsync<Employee>().Result;
                ViewBag.employee = emp;
                return View(emp);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri(URL);
            HttpResponseMessage response2 = Client.DeleteAsync("API/Employee/" + id).Result.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        EmployeeService es = new EmployeeService();
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {


            //List<employee> ls = es.GetMany(d => (d.email ==  lm.email)).ToList();
            

                FormsAuthentication.SetAuthCookie("1", true);
                return RedirectToAction("Index");
            
    

        }
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}

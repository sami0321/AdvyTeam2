using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class FicheMController : Controller
    {

        IFicheMetier fms = null;
        public EmployeService es = new EmployeService();
        public IReferenceCompetence rcs = new ReferenceCompetenceService();

        public FicheMController()
        {
            fms = new FicheMetierService();
        }

        // GET: FicheM
        public ActionResult Index(string filtre)
        {


            var list = fms.GetMany();//GetFichemetiers("Developpement");

            if (!String.IsNullOrEmpty(filtre))
            { list = list.Where(m => m.F_Famille_Competence.ToLower().Contains(filtre.ToLower())).ToList(); }
            return View(list);
        }

        // GET: FicheM/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            fichemetier p = fms.GetById(id);
            FicheMetierModel p1 = new FicheMetierModel()
            {
                description_f = p.description_f,
                F_Famille_Competence = p.F_Famille_Competence,
                nom_f = p.nom_f,
                Employee_U_ID = p.Employee_U_ID,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // GET: FicheM/Create
        public ActionResult Create()
        {
            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View();
        }

        // POST: FicheM/Create
        [HttpPost]
        public ActionResult Create(FicheMetierModel f)
        {

            fichemetier fm = new fichemetier()
            {

                description_f = f.description_f,
                F_Famille_Competence = f.F_Famille_Competence,
                nom_f = f.nom_f,
                Employee_U_ID=f.Employee_U_ID,
                
                
            };
            fms.Add(fm);
            fms.Commit();
            //Service.Dispose();

            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", fm.Employee_U_ID);
            return RedirectToAction("Index"); 
}

        // GET: FicheM/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            fichemetier p = fms.GetById(id);
            FicheMetierModel p1 = new FicheMetierModel()
            {
                description_f = p.description_f,
                F_Famille_Competence = p.F_Famille_Competence,
                nom_f = p.nom_f,
                Employee_U_ID = p.Employee_U_ID,
            };
            if (p == null)
                return HttpNotFound();

            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View(p1);
        }

        // POST: FicheM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FicheMetierModel f)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    fichemetier p = fms.GetById(id);

                    p.description_f = f.description_f;
                    p.nom_f = f.nom_f;
                    p.F_Famille_Competence = f.F_Famille_Competence;
                   // p.Employee_U_ID = f.Employee_U_ID;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    fms.Update(p);
                    fms.Commit();
                    // Service.Dispose();
                    ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", p.Employee_U_ID);
                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(f);

            }
            catch
            {
                return View();
            }
        }

        // GET: FicheM/Delete/5
        public ActionResult Delete(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            fichemetier p = fms.GetById(id);
            FicheMetierModel p1 = new FicheMetierModel()
            {
                description_f = p.description_f,
                F_Famille_Competence = p.F_Famille_Competence,
                nom_f = p.nom_f,
                Employee_U_ID = p.Employee_U_ID,


            };
            if (p == null)
                return HttpNotFound();

            return View(p1);
        }

        // POST: FicheM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FicheMetierModel f)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    fichemetier p = fms.GetById(id);
                    f = new FicheMetierModel()
                    { 
                    description_f = p.description_f,
                    nom_f = p.nom_f,
                    F_Famille_Competence = p.F_Famille_Competence,
                    // p.Employee_U_ID = f.Employee_U_ID;
                };
                if (p == null)
                        return HttpNotFound();
                    Console.WriteLine("deletedddddddddddddddddddddddddddddddd");
                    fms.Delete(p);
                    fms.Commit();
                    // Service.Dispose();

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(f);

            }
            catch
            {
                return View();
            }
        }

        // GET: FicheM/Create
        public ActionResult Show(int id)
        {
            var fm = fms.GetById(id);
            IEnumerable<referencecompetence> referencecompetences = rcs.GetEmployeeCompetences(fm.F_Famille_Competence, fm.Employee_U_ID.Value);
            foreach (referencecompetence referencecompetence in referencecompetences)
                if (rcs.EmpNeedsToBeTested(referencecompetence.id_cf))
                {
                    var fromAddress = new MailAddress("samibouaben76@gmail.com", "Test Email");
                    var toAddress = new MailAddress("guedouareskander@gmail.com");
                    const string fromPassword = "clubafricain1920";
                    string subject = "test"; //your subject line
                    string body = "test 2";// your body
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com", //example
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                        Timeout = 20000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body

                    }) 
                    { 
                    try
                    {
                            smtp.EnableSsl = true;
                            smtp.Send(message);
                        Debug.WriteLine("mail Send");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("*********************************" + ex.ToString());
                    }

                    }
                }
            return View(referencecompetences);
        }

        // POST: FicheM/Create
        [HttpPost]
        public ActionResult Show(FicheMetierModel f)
        {

            fichemetier fm = new fichemetier()
            {

                description_f = f.description_f,
                F_Famille_Competence = f.F_Famille_Competence,
                nom_f = f.nom_f,
                Employee_U_ID = f.Employee_U_ID,
            };
            fms.Add(fm);
            fms.Commit();
            //Service.Dispose();

            ViewBag.Employee_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", fm.Employee_U_ID);
            return RedirectToAction("Index");
        }
    }
}

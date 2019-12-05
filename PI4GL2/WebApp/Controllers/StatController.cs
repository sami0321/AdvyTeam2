using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI4GL2.Data;

using PI4GL2.Service;
namespace WebApp.Controllers
{
    public class StatController : Controller
    {
        // GET: Stat

        EmployeeService es = new EmployeeService();
        public ActionResult Index()
        {
            ViewBag.result = es.GetMany(d => d.state == true);
            return View();
        }

        MyDBContext db = new MyDBContext();

        
        public class CustomData
        {
            public string state { get; set; }
            public int value { get; set; }
        }



        public JsonResult getData(int id)
        {
            var sql = "select d.type as state, count(d.id) as value from formation d where d.employee_id ="+id+" GROUP BY d.type";
            List<CustomData> list = db.Database.SqlQuery<CustomData>(sql).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
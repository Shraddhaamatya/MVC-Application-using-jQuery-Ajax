using MvcApplication117.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication117.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        SevenDBEntities3 _db = new SevenDBEntities3();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_db.tblEmployees.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(tblEmployee emp)
        {
            _db.tblEmployees.Add(emp);
            return Json(_db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            tblEmployee tb = _db.tblEmployees.Where(e => e.EmployeeId == ID).FirstOrDefault();
            return Json(tb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(tblEmployee emp)
        {
            tblEmployee employee = _db.tblEmployees.Where(e => e.EmployeeId == emp.EmployeeId).FirstOrDefault();
            employee.Name = emp.Name;
            employee.Age = emp.Age;
            employee.State = emp.State;
            employee.Country = emp.Country;
            return Json(_db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            tblEmployee emp=_db.tblEmployees.Where(e=>e.EmployeeId==ID).FirstOrDefault();
            _db.tblEmployees.Remove(emp);
            return Json(_db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }

    }
}

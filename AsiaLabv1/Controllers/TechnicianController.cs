using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsiaLabv1.Models;
using AsiaLabv1.Services;

namespace AsiaLabv1.Controllers
{
    public class TechnicianController : Controller
    {
        PatientTestService pts = new PatientTestService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPatientInfo()
        {
            
            var patientInfo=pts.GetPatientTests();
            return Json(patientInfo,JsonRequestBehavior.AllowGet);
        }

        public ActionResult PerformTest()
        {
            GetPatientInfo();
            return View();
        }
        

    }
}

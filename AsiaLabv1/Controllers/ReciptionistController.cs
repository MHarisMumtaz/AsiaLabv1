using AsiaLabv1.Models;
using AsiaLabv1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsiaLabv1.Controllers
{
    public class ReciptionistController : Controller
    {
        UserService UserServices = new UserService();
        PatientService PatientServices = new PatientService();
        PatientTestService PatientTestService = new PatientTestService();
        GenderService GenderServices = new GenderService();
        TestDeptService TestDeptServices = new TestDeptService();
        TestCategoryService TestCategoryServices = new TestCategoryService();
        TestSubCategoryService TestSubCategoryServices = new TestSubCategoryService();
        ReferDoctorsService ReferDoctorsServices = new ReferDoctorsService();

        public ActionResult RegisterPatient()
        {
            var model = new PatientModel();
            var Genders = GenderServices.GetAll();
            foreach (var item in Genders)
            {
                model.Genders.Add(new SelectListItem
                {
                    Text = item.GenderDescription,
                    Value = item.Id.ToString()
                });
            }
            var allDept = TestDeptServices.GetAllDept();

            foreach (var Dept in allDept)
            {
                model.Departments.Add(new SelectListItem
                {
                    Value = Dept.Id.ToString(),
                    Text = Dept.DepartmentName
                });
            }

            var allrefers = ReferDoctorsServices.GetAllReferDoctors();
            foreach (var refer in allrefers)
            {
                model.ReferredDoctors.Add(new SelectListItem
                {
                    Value = refer.Id.ToString(),
                    Text = refer.ReferredDoctorName
                });
            }
            return View("RegisterPatient", model);
        }

        [HttpPost]
        public ActionResult GetTests(int Id)
        {
            var Tests = TestSubCategoryServices.GetSubCategTestsByTestCategoryId(Id);
            var TestList = new List<TestSubCategoryModel>();
            
            #region for test code delete later
            //for (int i = 0; i < 10; i++)
            //{
            //    TestList.Add(new TestSubCategoryModel
            //    {
            //        Id = i,
            //        Rate = i*5,
            //        TestSubcategoryName = "Testname"+i.ToString()
            //    });
            //}
            #endregion

            foreach (var item in Tests)
            {
                TestList.Add(new TestSubCategoryModel
                {
                    Id = item.Id,
                    Rate = item.Rate,
                    TestSubcategoryName = item.TestSubcategoryName
                });
            }

            return Json(TestList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetSubCategory(int Id)
        {
            var TestList = TestCategoryServices.GetTestCategoryByDeptId(Id);
            var TestsList = new List<Tests>();
            foreach (var item in TestList)
            {
                TestsList.Add(new Tests
                {
                    Id = item.Id,
                    Name = item.TestName
                });
            }
            return Json(TestsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPatient(PatientModel model)
        {
            #region testing code should be delete
            //var model=new PatientModel(){
            //    BranchId=1,
            //    Name="firstTestPatient",
            //    Email="Testpatient@gmail.com",
            //    GenderId=1,
            //    DateofBirth=DateTime.Now,
            //    PhoneNumber="987987697",
            //    ReferredId=-1
            //};
            #endregion
            if (model.PatientTestIds.Count > 0)
            {
                int UserId = Convert.ToInt32(Session["loginuser"].ToString());
                model.BranchId = UserServices.GetUserBranch(UserId).Id;
                PatientServices.Add(model);

                foreach (var TestId in model.PatientTestIds)
                {
                    PatientTestService.Add(new PatientTest
                    {
                        PatientId = model.Id,
                        TestSubcategoryId = TestId
                    });
                }
                return Json("SuccessFully Added Patient", JsonRequestBehavior.AllowGet);
            }
            return Json("Please assign tests for patients", JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult PrintReport()
        {
            return View();
        }

       

    }
}

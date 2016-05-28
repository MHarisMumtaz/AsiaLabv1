using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Services
{
    public class PatientTestService
    {
        Repository<PatientTest> _PatientTestService = new Repository<PatientTest>();
        Repository<TestSubcategory> _TestSubCategoryRepository = new Repository<TestSubcategory>();
        Repository<Patient> _PatientRepository = new Repository<Patient>();
        Repository<PatientTestResult> _PatientTestResultRepository= new Repository<PatientTestResult>();
        Repository<TechnicianPatientsTest> _TechnicianPatientTestRepository = new Repository<TechnicianPatientsTest>();

        public void Add(PatientTest Patienttest)
        {
            _PatientTestService.Insert(Patienttest);
        }
        public List<Patient> GetPatientTests()
        {
            //var query = (from pt in _PatientTestService.Table
            //             join p in _PatientRepository.Table
            //             on pt.PatientId equals p.Id
            //             where !_PatientTestResultRepository.Table.Any(ptr => ptr.PatientTestId == pt.Id)
            //             select pt).ToList<PatientTest>().GroupBy(test => test.Id).Select(grp => grp.First()).ToList();

            var check2 = (from pt in _PatientTestService.Table
                          join tr in _PatientTestResultRepository.Table
                          on pt.Id equals tr.PatientTestId
                          select pt.PatientId).ToList();

            //var check = (from tr in _PatientTestResultRepository.Table
            //             select tr.PatientTestId).ToList();

            var query = (from p in _PatientRepository.Table
                         join pt in _PatientTestService.Table
                         on p.Id equals pt.PatientId
                         //where !_PatientTestResultRepository.Table.Any(ptr => ptr.PatientTestId == pt.Id)
                         where !check2.Contains(pt.PatientId)
                         select p).ToList<Patient>().GroupBy(test => test.Id).Select(grp => grp.First()).ToList();

            
               

            return query;
        }

        public List<PatientTest> GetPatientTestsById(int id)
        {
            var query = (from pt in _PatientTestService.Table
                         join t in _TestSubCategoryRepository.Table
                         on pt.TestSubcategoryId equals t.Id
                         //where !_PatientTestResultRepository.Table.Any(ptr => ptr.PatientTestId == pt.Id)
                         //&& pt.PatientId == id
                         where pt.PatientId == id
                         select pt).ToList<PatientTest>();

            return query;
        }

        public void InsertPatientTestResults(PatientTestResult model)
        {
            _PatientTestResultRepository.Insert(model);
        }

        public void InsertTechnicianPatientTests(TechnicianPatientsTest model)
        {
            _TechnicianPatientTestRepository.Insert(model);
        }
    }
}
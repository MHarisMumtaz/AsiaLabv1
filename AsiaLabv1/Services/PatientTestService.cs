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

        public void Add(PatientTest Patienttest)
        {
            _PatientTestService.Insert(Patienttest);
        }
        public List<PatientTest> GetPatientTests()
        {
            var query = (from pt in _PatientTestService.Table
                         join p in _PatientRepository.Table
                         on pt.PatientId equals p.Id
                         join t in _TestSubCategoryRepository.Table
                         on pt.TestSubcategoryId equals t.Id
                         where !_PatientTestResultRepository.Table.Any(ptr => ptr.PatientTestId == pt.Id)
                         select pt).ToList<PatientTest>();
             
            return query;
        }

        public void SubmitResults(PatientTestResult model) 
        {
            _PatientTestResultRepository.Insert(model);
        }
    }
}
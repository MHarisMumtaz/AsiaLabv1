using AsiaLabv1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Services
{
    public class PatientTestService
    {

        Repository<PatientTest> _PatientTestRepository = new Repository<PatientTest>();
        Repository<TestSubcategory> _TestSubCategoryRepository = new Repository<TestSubcategory>();
        Repository<Patient> _PatientRepository = new Repository<Patient>();
        Repository<PatientTestResult> _PatientTestResultRepository= new Repository<PatientTestResult>();

        public void Add(PatientTest Patienttest)
        {
            _PatientTestRepository.Insert(Patienttest);
        }
        
        public List<PatientTest> GetPatientTests()
        {
            var query = _PatientTestRepository.GetAll();
             
            return query;
        }

        public void SubmitResults(PatientTestResult model) 
        {
            _PatientTestResultRepository.Insert(model);
        }
    }
}
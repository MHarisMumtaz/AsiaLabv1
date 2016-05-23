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

        public void Add(PatientTest Patienttest)
        {
            _PatientTestService.Insert(Patienttest);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1
{
    public class RequiredItem
    {
        public int Id { get; set; }
        public string testName { get; set; }
    }

    public class RequiredTest
    {
        public int Id { get; set; }
        public string testName { get; set; }
        public double upperBound { get; set; }
        public double lowerBound { get; set; }
        public string unit { get; set; }
        public double rate { get; set; }
<<<<<<< HEAD
    }

    public class RequiredPatient
    {
        public int Id { get; set; }
        public string PatientNumber { get; set; }
        public string PatientName{get;set;}

    }

    public class RequiredTechnicianItems
    {
        public string PatientNumber { get; set; }
        public string PatientName { get; set; }

        public List<RequiredTest> PatientTests { get; set; }
    }
=======
    }  
    
>>>>>>> f49991fb2731d99d6f3448f6a14097e69ba5afd2
}
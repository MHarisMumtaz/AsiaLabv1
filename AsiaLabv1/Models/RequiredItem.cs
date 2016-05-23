using System;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaulisBlog.Models
{
    public class Fan
    {
        static int countIDs = 0;

        public Fan()
        {
            this.ID = countIDs;
            countIDs++;
        }

        public int ID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string gender { get; set; }

        public DateTime birthDate { get; set; }

        public int clubSeniority { get; set; }
    }
}
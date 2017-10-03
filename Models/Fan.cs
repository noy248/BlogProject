using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Fan firs-tname")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Fan last-name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Fan gender")]
        [DataType(DataType.Custom)]
        public string Gender { get; set; }


        [Display(Name = "Fan birthdate")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDate { get; set; }

        [Display(Name = "Fan seniority")]
        [DataType(DataType.Currency)]
        public int ClubSeniority { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShaulisBlog.Models
{
    public class Comment
    {
        static int countIDs = 0;

        public Comment()
        {
            this.ID = countIDs;
            countIDs++;
        }


        public int ID { get; set; }

        public int PostID { get; set; }


        [Display(Name = "Commant title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Commanter name")]
        [DataType(DataType.Text)]
        public string Commenter { get; set; }

        [Display(Name = "Commanter site address")]
        [DataType(DataType.Url)]
        public string CommenterSiteAddr { get; set; }

        [Display(Name = "Commant text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "Commant writing Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CommentDate { get; set; }

        Post CommentPost { get; set; }

    }
}

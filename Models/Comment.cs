using System;
using System.Collections.Generic;
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

        public string Title { get; set; }

        public int PostID { get; set; }

        public string Commenter { get; set; }

        public string CommenterSiteAddr { get; set; }

        public string Text { get; set; }

        public DateTime CommentDate { get; set; }

        Post CommentPost { get; set; }

    }
}
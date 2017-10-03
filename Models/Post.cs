using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShaulisBlog.Models
{
    public class Post
    {
        static int countIDs = 0;

        public Post()
        {
            this.ID = countIDs;
            countIDs++;
        }

        [Required]
        public int ID { get; set; }

        public string   Title { get; set; }

        public string Author { get; set; }

        public string AuthorSiteAddr { get; set; }

        public DateTime PostDate { get; set; }

        public string PostText { get; set; }

        public string Photos { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
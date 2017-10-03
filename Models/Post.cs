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

        [Display(Name = "Post title")]
        [DataType(DataType.Text)]
        public string   Title { get; set; }

        [Display(Name = "Author name")]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [Display(Name = "Author website address")]
        [DataType(DataType.Url)]
        public string AuthorSiteAddr { get; set; }

        [Display(Name = "Post writing Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [Display(Name = "Post text")]
        [DataType(DataType.MultilineText)]
        public string PostText { get; set; }

        [Display(Name = "Post photo")]
        [DataType(DataType.Text)]
        public string Photos { get; set; }

        public List<Comment> Comments { get; set; }

    }
}

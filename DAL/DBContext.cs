using ShaulisBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShaulisBlog.DAL
{
    public class DBContext : DbContext
    {
        public DbSet<Post> _posts { get; set; }
        public DbSet<Fan> _Fans { get; set; }
        public DbSet<Comment> _comments { get; set; }
    }
    
    
}
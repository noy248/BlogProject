using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShaulisBlog.DAL;
using ShaulisBlog.Models;
using System.Data.Entity.Core.Objects;

namespace ShaulisBlog.Controllers
{
    public class BlogController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Blog
        public ActionResult Index(int? postID)
        {
            List<Post> lsPosts =  db._posts.ToList();

            // The default page of the blog 
             if (postID == null)
             {
                //`return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View(lsPosts.First());
             }

             // getting the specific post if specified
             Post post = db._posts.Find(postID);
             if (post == null)
             {
                 return HttpNotFound();
             }

            return View(post);
        }

        /// <summary>
        ///   GET: Blog/Details/5
        /// </summary>
        /// <param name="id">the current post id to show all of its details - only the post</param>
        /// <returns>the post itself</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db._posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

     
        /// <summary>
        /// Blog/Create
        /// </summary>
        /// <param name="ID">The id of a given post and adding it a new comment</param>
        /// <returns>The new comment </returns>
        public ActionResult Create(int ID)
        {
            Comment comm = new Comment();
            comm.PostID = ID;
            Post post = db._posts.Find(comm.PostID);
            comm.CommentPost = post;
            comm.CommentDate = DateTime.Now.Date;

            return View(comm);
        }

        /// <summary>
        ///  POST: Blog/Create
        ///  To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ///  more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="comm">getting the comment that created</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,PostID,Title,Commenter,CommenterSiteAddr,Text")] Comment comm)
        {
            // if the giving vomment valid adding the relavant date and post 
            // adding the new comment
            if (ModelState.IsValid)
            {
                db.Entry(comm).State = EntityState.Modified;

               

                try
                {
                    db._comments.Add(comm);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict, e.Message);
                }
               
                return RedirectToAction("Index");
            }

            return View(comm);
        }

        /// <summary>
        /// GET: Blog/Edit/5
        /// editing the comment given in the id
        /// </summary>
        /// <param name="id"> the comment id</param>
        /// <returns>the comment if exist</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = db._comments.Find(id);

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        /// <summary>
        /// editing the giving comment 
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,PostID,Title,Commenter,CommenterSiteAddr,Text")] Comment comm)
        {
            if (ModelState.IsValid)
            {
                comm.CommentDate = DateTime.Now.Date;
                db.Entry(comm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comm);
        }

        /// <summary>
        /// finding and showing the comment to delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comm = db._comments.Find(id);
            if (comm == null)
            {
                return HttpNotFound();
            }
            return View(comm);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// deleting the given comment 
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <returns></returns>
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comm = db._comments.Find(id);
            db._comments.Remove(comm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

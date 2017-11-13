using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.Models;

namespace ShauliBlog.Controllers
{
    public class PostController : Controller
    {
        private PostDbContext db = new PostDbContext();

        // GET: /Post/
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: /Post/
        public ActionResult Blog()
        {
            List<Post> AllPosts = db.Posts.ToList();

            for (int j = 0; j < AllPosts.Count; j++)
            { 
                List<Comment> CurrPostComments = db.Comments.ToList();

                for (int i = CurrPostComments.Count - 1; i >= 0; i--)
                {
                    if (CurrPostComments[i].PostID != AllPosts[j].ID)
                    {
                        CurrPostComments.Remove(CurrPostComments[i]);
                    }
                }

                AllPosts[j].PostComments = CurrPostComments;
            }


            return View(AllPosts.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Blog([Bind(Include = "ID,PostID,CommentTitle,CommentWriterName,CommentWriterSiteUrl,CommentTextContent")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }

            List<Post> AllPosts = db.Posts.ToList();

            for (int j = 0; j < AllPosts.Count; j++)
            {
                List<Comment> CurrPostComments = db.Comments.ToList();

                for (int i = CurrPostComments.Count - 1; i >= 0; i--)
                {
                    if (CurrPostComments[i].PostID != AllPosts[j].ID)
                    {
                        CurrPostComments.Remove(CurrPostComments[i]);
                    }
                }

                AllPosts[j].PostComments = CurrPostComments;
            }


            return View(AllPosts.ToList());
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            else
            {
                List<Comment> CurrPostComments = db.Comments.ToList();

                for (int i = CurrPostComments.Count - 1; i >= 0; i--)
                {
                    if (CurrPostComments[i].PostID != id)
                    {
                        CurrPostComments.Remove(CurrPostComments[i]);
                    }
                }

                post.PostComments = CurrPostComments;
                return View(post);
            }
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PostTitle,PostWriterName,PostWriterSiteUrl,PublishDate,PostTextContent,ImageUrl,VideoUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PostTitle,PostWriterName,PostWriterSiteUrl,PublishDate,PostTextContent,ImageUrl,VideoUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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

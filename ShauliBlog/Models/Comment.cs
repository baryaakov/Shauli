using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Display(Name = "Post")]
        public int PostID { get; set; }
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }
        [Display(Name = "Writer Name")]
        public string CommentWriterName { get; set; }
        [Display(Name = "Writer WebSite")]
        public string CommentWriterSiteUrl { get; set; }
        [Display(Name = "Content")]
        public string CommentTextContent { get; set; }

        [ForeignKey("PostID")]
        [Display(Name = "Post")]
        public Post PostRef { get; set; }

        public Comment()
        {

        }

        public class CommentDbContext : DbContext
        {
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Display(Name="Post Title")]
        public string PostTitle { get; set; }
        [Display(Name = "Writer Name")]
        public string PostWriterName { get; set; }
        [Display(Name = "Writer WebSite")]
        public string PostWriterSiteUrl { get; set; }
        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }
        [Display(Name = "Content")]
        public string PostTextContent { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        [Display(Name = "Video Url")]
        public string VideoUrl { get; set; }
        [Display(Name = "Comments")]
        public List<Comment> PostComments { get; set; }

        public Post()
        {
            this.PostComments = new List<Comment>();
        }
    }

    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
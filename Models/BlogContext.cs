using Microsoft.EntityFrameworkCore;

namespace SampleBlog.Models
{
    public class BlogContext : DbContext
    {

        public BlogContext() { }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Blog;User Id=sa;Password=sasa");
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }


    }
}
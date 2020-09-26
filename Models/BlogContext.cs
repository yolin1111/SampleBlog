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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add the shadow property to the model
            modelBuilder.Entity<Post>()
                .Property<int>("FK_Posts_Blogs_BlogId");

            // Use the shadow property as a foreign key
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blogs)
                .WithMany(b => b.Posts)
                .HasForeignKey("FK_Posts_Blogs_BlogId");
        }
    }
}
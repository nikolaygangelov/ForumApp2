using ForumApp2.Infrastructure.Configuration;
using ForumApp2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp2.Infrastructure.Data
{
    public class ForumApp2DbContext : DbContext
    {
        public ForumApp2DbContext(DbContextOptions<ForumApp2DbContext> options) : 
            base(options)
        {
                
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

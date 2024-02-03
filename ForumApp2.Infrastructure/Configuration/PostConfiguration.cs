using ForumApp2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp2.Infrastructure.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private Post[] initialPost = new Post[]
        {
            new Post { Id = 1, Title = "My first post", Content = "My first post content"},
            new Post { Id = 2, Title = "My second post", Content = "My second post content"},
            new Post { Id = 3, Title = "My third post", Content = "My third post content"}
        };
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(initialPost);
        }
    }
}

using ForumApp2.Core.Contracts;
using ForumApp2.Core.Models;
using ForumApp2.Infrastructure.Data;
using ForumApp2.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp2.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumApp2DbContext context;

        /// <summary>
        /// using dependancy injection through constructor
        /// gives access to the instance of ForumApp2DbContext - context
        /// </summary>
        /// <param name="context"></param>
        public PostService(ForumApp2DbContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            // using identical properties in order to map successfully
            // using async await pattern
            var allPosts = await context.Posts
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .AsNoTracking() // just viewing posts without processing
                .ToListAsync();

            return allPosts;
        }
        public async Task AddPostAsync(PostModel model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(entity);

            // actual adding the posts
            await context.SaveChangesAsync();
        }

        public async Task<PostModel> GetPostByIdAsync(int id)
        {
            var entity = await context.Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            // validating found post
            if (entity == null)
            {
                throw new ArgumentException("Invalid post");
            }

            return new PostModel()
            {
                Id = id,
                Title = entity.Title,
                Content = entity.Content
            };
        }

        public async Task UpdatePostAsync(PostModel model)
        {
            // covers the repeating code 
            var entity = await GetByIdAsync(model.Id);

            entity.Title = model.Title;
            entity.Content = model.Content;

            // actual changing of post
            await context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            context.Remove(entity);

            // actual removing the post
            await context.SaveChangesAsync();
        }

        private async Task<Post> GetByIdAsync(int id)
        {
            // using FindAsync method for quick searching 
            var entity = await context.Posts.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid post");
            }

            return entity;
        }
    }
}

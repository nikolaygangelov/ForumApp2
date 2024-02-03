using ForumApp2.Core.Models;
using ForumApp2.Infrastructure.Data.Models;

namespace ForumApp2.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task AddPostAsync(PostModel model);
        Task<PostModel> GetPostByIdAsync(int id);
        Task UpdatePostAsync(PostModel model);
        Task DeletePostAsync(int id);
    }
}

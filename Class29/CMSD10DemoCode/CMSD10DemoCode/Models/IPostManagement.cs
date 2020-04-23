using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Models
{
    public interface IPostManagement
    {
        // Create
        Task<Post> CreatePostAsync(Post post);

        // Read
        Task<Post> GetPostByIdAsync(int id);
        Task<List<Post>> GetAllPostsAsync();

        // Update
        Task UpdatePostAsync(Post post);

        // Delete
        Task RemovePostAsync(int id);
    }
}

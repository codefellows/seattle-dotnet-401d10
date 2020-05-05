using CMSD10DemoCode.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Models.Services
{
    public class PostService : IPostManagement
    {
        private CMSDbContext _context;

        public PostService(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<List<Post>> GetAllPostsAsync() => await _context.Posts.ToListAsync();

        public async Task<Post> GetPostByIdAsync(int id) => await _context.Posts.FindAsync(id);

        public async Task RemovePostAsync(int id)
        {
            var post = await GetPostByIdAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}

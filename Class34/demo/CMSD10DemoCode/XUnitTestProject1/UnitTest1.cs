using System;
using Xunit;
using CMSD10DemoCode;
using CMSD10DemoCode.Models;
using Microsoft.EntityFrameworkCore;
using CMSD10DemoCode.Data;
using CMSD10DemoCode.Models.Services;
using System.Threading.Tasks;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddTitleToPost()
        {
            Post post = new Post();
            post.Title = "The Beginning of the End!";

            Assert.Equal("The Beginning of the End!", post.Title);
        }

        [Fact]
        public void CanSetPostContent()
        {
            Post post = new Post()
            {
                Title = "Let's Do this!",
                Content = "This is my data!"
            };

            Assert.Equal("This is my data!", post.Content);
        }

        [Fact]
        public async Task CanAddPostToDB()
        {
            // add this nuget package to your project: 
            // Install - Package Microsoft.EntityFrameworkCore.InMemory - Version 3.1.3
            // Arrange
            DbContextOptions<CMSDbContext> options = new DbContextOptionsBuilder<CMSDbContext>()
                .UseInMemoryDatabase("CanAddPostToDB")
                .Options;
            
            // open the connection to the database
            using (CMSDbContext context = new CMSDbContext(options))
            {
                PostService ps = new PostService(context);

                Post post = new Post()
                {
                    Title = "This is our Test Post",
                    Content = "Let's see if this works! YAYY!"
                };

               var result = await ps.CreatePostAsync(post);

                // Check if the post exists through the context directly
                var data = context.Posts.Find(post.ID);
                Assert.Equal(result, data);

                // change our service to have a return and check the data that came back
                Assert.Equal("This is our Test Post", post.Title);

            }

        }
    }
}

using CMSD10DemoCode.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Components
{
    // You can have either the Tag, or the View Compnents inherited class
    // you can also have both to be super explicit. 
    [ViewComponent]
    public class TopPosts : ViewComponent
    {
        private CMSDbContext _context;

        public TopPosts(CMSDbContext context)
        {
            _context = context;
        }

        // Required/reserved method name is Invoke or InvokeAsync

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            // make a call to my posts table and get the latest 3 results/

           var posts =  _context.Posts.OrderByDescending(potato => potato.ID)
                            .Take(number);

            return View(posts);
        }
    }
}

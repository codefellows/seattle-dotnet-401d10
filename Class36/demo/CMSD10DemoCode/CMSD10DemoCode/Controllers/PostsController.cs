using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSD10DemoCode.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSD10DemoCode.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class PostsController : Controller
    {
        private CMSDbContext _context;

        public PostsController(CMSDbContext context)
        {
            _context = context;
        }
        // GET: Posts
        // route: .com/Posts
        public async Task<ActionResult> Index()
        {
            var posts = await _context.Posts.ToListAsync();
            return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
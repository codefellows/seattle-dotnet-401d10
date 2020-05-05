using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CMSD10DemoCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CMSD10DemoCode.Pages.PictureUpload
{
    public class IndexModel : PageModel
    {
        public IndexModel(IConfiguration congfiguration)
        {
            Blob = new Blob(congfiguration);
        }

        public Blob Blob { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);

            }

            await Blob.UploadFile("cats", "kittyKat", filePath);

            // get the file
            var blob = await Blob.GetBlob("kittyKat", "cats");

            var kitCat = blob.Uri;


            return Page();
        }
    }
}

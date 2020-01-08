using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadServer.Controllers
{
    public class UploadsController : Controller
    {


        public Tuple<string, string> folderNameandPath()
        {
            var folderName = Path.Combine("UploadStaticFiles", "CustomerProfilePic");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            return new Tuple<string, string>(folderName, pathToSave);
        }

        // GET: /<controller>/
        public ObjectResult Upload(string folderName,string pathToSave)
        {
            //https://code-maze.com/upload-files-dot-net-core-angular/
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return StatusCode(500, "Bad Request");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

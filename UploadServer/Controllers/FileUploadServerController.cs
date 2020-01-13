using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadServerController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file)
        {
            //https://code-maze.com/upload-files-dot-net-core-angular/
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

                var folderName = Path.Combine("UploadStaticFiles", "CustomerProfilePic");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
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



        [HttpGet]
        [Route("rktest")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "up1", "value2" };
        }
    }
}
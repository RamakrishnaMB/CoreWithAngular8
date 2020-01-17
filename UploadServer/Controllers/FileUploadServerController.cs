using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                    bool addPath = true; bool addQuery = true;
                    var uriBuilder = new UriBuilder
                    {
                        Scheme = Request.Scheme,
                        Host = Request.Host.Host,
                        Port = Request.Host.Port.GetValueOrDefault(80),
                        Path = addPath ? Request.Path.ToString() : default(string),
                        Query = addQuery ? Request.QueryString.ToString() : default(string)
                    };
                    var url = uriBuilder.Uri.ToString();
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath, url });
                }
                else
                {
                    return StatusCode(500, "Bad Request");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }


        [HttpPost]
        [Route("DeleteProfilePic")]
        public IActionResult DeleteFile(string filePath)
        {
            //https://www.c-sharpcorner.com/article/calling-web-api-using-httpclient/
            string msg = "File deleted successfully";
            try
            {
                var isDeleted = RemoveFileFromServer(filePath);
                return Ok(new { msg });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        private bool RemoveFileFromServer(string path)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            if (!System.IO.File.Exists(fullPath)) return false;

            try //Maybe error could happen like Access denied or Presses Already User used
            {
                System.IO.File.Delete(fullPath);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }



        [HttpGet]
        [Route("rktest")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "up1", "value2" };
        }
    }
}
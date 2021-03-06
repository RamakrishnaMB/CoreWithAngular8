﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadServer.Controllers
{
    public class UploadsController : Controller
    {
        private readonly FilePathUploadServer _path;

        public UploadsController(IOptions<FilePathUploadServer> filePathUploadServer)
        {
            _path = filePathUploadServer.Value;
        }
        //public Tuple<string, string> folderNameandPath()
        //{
        //    var folderName = Path.Combine("UploadStaticFiles", "CustomerProfilePic");
        //    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //    return new Tuple<string, string>(folderName, pathToSave);
        //}

        // GET: /<controller>/
        public ObjectResult Upload(IFormFile file)
        {
            //https://code-maze.com/upload-files-dot-net-core-angular/
            try
            {
                var test = _path;
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
    }
}

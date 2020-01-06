using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoreBusinessLogic.PdfConfig.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shark.PdfConvert;

namespace CoreWebAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsPDFController : ControllerBase
    {
        private readonly IGeneratePdf generatPdf;

        public ReportsPDFController(IGeneratePdf generatPdf)
        {
            this.generatPdf = generatPdf;
        }

        [HttpPost]
        [Route("downloadSamplePDF")]
        public async Task<FileContentResult> DownloadSamplePDF()
        {
            var fileContentResult = await this.generatPdf.GeneratePDFAsync();
            //  return StatusCode((int)HttpStatusCode.OK, fileContentResult);
            return fileContentResult;

        }

    }
}
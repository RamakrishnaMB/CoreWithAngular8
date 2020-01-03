using CoreBusinessLogic.PdfConfig.Interface;
using Microsoft.AspNetCore.Mvc;
using Shark.PdfConvert;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreBusinessLogic.PdfConfig.Implementation
{
    public class GeneratePdf : IGeneratePdf
    {
        public FileContentResult GeneratePDFAsync()
        {
            //nuget install - Shark.PdfConvert ver 1.0.3
            //Note: https://github.com/cp79shark/Shark.PdfConvert
            //install https://wkhtmltopdf.org/downloads.html
            //https://www.c-sharpcorner.com/article/Asp-Net-mvc-file-upload-and-download/

            PdfConversionSettings config = new PdfConversionSettings
            {
                Title = "My Static Content",
                Size = PdfPageSize.A4,
                Content = @"<h3>PDf generated from dot net core!!!</h3>
		                <script>document.querySelector('h1').style.color = 'rgb(128,0,0)';</script>"
                //   OutputPath = @"C:\GeneratedPDF\test.pdf"
            };
            var memoryStream = new MemoryStream();
            PdfConvert.Convert(config, memoryStream);
            var fileName = "myfileName.pdf";
            var mimeType = "application/pdf";
            return new FileContentResult(memoryStream.ToArray(), mimeType)
            {
                FileDownloadName = fileName
            };
        }
    }
}

using System.IO;
using System.Threading.Tasks;
using CoreBusinessLogic.PdfConfig.Implementation;
using CoreBusinessLogic.PdfConfig.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CoreWebAppRazor.Controllers
{
    public class PDFDemoController : Controller
    {
        private readonly IGeneratePdf generatPdf;

        public PDFDemoController(IGeneratePdf generatPdf)
        {
            this.generatPdf = generatPdf;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> DownloadAsync()
        {
            FileContentResult fileContentResult = await this.generatPdf.GeneratePDFAsync();
            return fileContentResult;
        }
    }
}
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
        private readonly IGenerateWord generateWord;

        public PDFDemoController(IGeneratePdf generatPdf,IGenerateWord generateWord)
        {
            this.generatPdf = generatPdf;
            this.generateWord = generateWord;
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

        public async Task<IActionResult> DownloadWordAsync()
        {
            FileContentResult fileContentResult = await this.generateWord.GenerateDemoWord();
            return fileContentResult;
        }

    }
}
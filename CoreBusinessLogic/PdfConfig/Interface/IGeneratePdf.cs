using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CoreBusinessLogic.PdfConfig.Interface
{
    public interface IGeneratePdf
    {
      FileContentResult GeneratePDFAsync();
    }
}

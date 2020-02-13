using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.PdfConfig.Interface
{
    public interface IGenerateWord
    {
        Task<FileContentResult> GenerateDemoWord();
    }
}

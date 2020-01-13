using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoreBusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public UploadFilesController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public async Task<IActionResult> UploadAsync()
        {
            var file = Request.Form.Files[0];
            return await this.customerService.UploadProfilePicAsync(file);
        }
    }
}
using CoreBusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using System.Threading.Tasks;

namespace CoreWebAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsServices contactUsServices;

        public ContactUsController(IContactUsServices contactUsServices)
        {
            this.contactUsServices = contactUsServices;
        }

        [HttpPost]
        [Route("ContactUSEmail")]
        public IActionResult AddContactUs([FromBody][Bind("Name,Email,Message")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                this.contactUsServices.ContactUsSendEmail(contactUs);
            }
            return StatusCode((int)HttpStatusCode.Created, contactUs);
        }
    }
}
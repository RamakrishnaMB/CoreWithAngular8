
using CoreBusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace CoreWebAppRazor.Controllers
{
    public class ContactController : Controller
    {
 
        private readonly IContactUsServices contactUsServices;

        public ContactController( IContactUsServices contactUsServices)
        {
            this.contactUsServices = contactUsServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactUs contactUs)
        {
            await this.contactUsServices.ContactUsSendEmailAsync(contactUs);
            //this.emailService.Send(emailMessage);
            ViewBag.result = "We will contact you soon!";
            return View();
        }
    }
}
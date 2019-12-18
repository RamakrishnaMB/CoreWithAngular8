
using CoreBusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public IActionResult Index(ContactUs contactUs)
        {
            this.contactUsServices.ContactUsSendEmail(contactUs);
            //this.emailService.Send(emailMessage);
            ViewBag.result = "We will contact you soon!";
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration.EmailConfig;
using Configuration.EmailConfig.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CoreWebAppRazor.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService emailService;

        public ContactController(IEmailService emailService)
        {
            this.emailService = emailService;
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

            EmailMessage emailMessage = new EmailMessage
            {
                Subject = "Request for Contact details from " + contactUs.Name,
                Content = contactUs.Message + "</br>" + "Name " + contactUs.Name + "</br>" + "Email " + contactUs.Email + "</br>" + "",
                FromAddresses = new List<EmailAddress> { new EmailAddress
                {
                    Address="findingRK@gmail.com"
                }
                },
                ToAddresses = new List<EmailAddress> { new EmailAddress
               {
                   Name = "RK",
                   Address = "ramakrishnamb@gmail.com",
               }}
            };
            //this.emailService.Send(emailMessage);
            ViewBag.result = "We will contact you soon!";
            return View();
        }
    }
}
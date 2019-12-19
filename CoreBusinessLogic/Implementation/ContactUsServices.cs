using CoreBusinessLogic.Interface;
using Models;
using System.Collections.Generic;
using Configuration.EmailConfig.Interface;
using Configuration.EmailConfig;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Implementation
{
    public class ContactUsServices : IContactUsServices
    {
        private readonly IEmailService emailService;

        public ContactUsServices(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public async Task ContactUsSendEmailAsync(ContactUs contactUs)
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
            await this.emailService.Send(emailMessage);
        }
    }
}

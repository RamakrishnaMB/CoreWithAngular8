using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.EmailConfig.Interface
{
    public interface IEmailService
    {
        Task Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}

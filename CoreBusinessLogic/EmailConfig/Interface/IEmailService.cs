using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.EmailConfig.Interface
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}

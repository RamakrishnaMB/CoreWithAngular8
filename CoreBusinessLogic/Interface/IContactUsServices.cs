using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public interface IContactUsServices
    {
        void ContactUsSendEmail(ContactUs contactUs);
    }
}

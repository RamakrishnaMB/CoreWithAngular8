using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Interface
{
    public interface IContactUsServices
    {
        Task ContactUsSendEmailAsync(ContactUs contactUs);
    }
}

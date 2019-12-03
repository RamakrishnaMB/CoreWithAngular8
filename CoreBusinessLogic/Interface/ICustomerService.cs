using CoreDataLayer.ModelsDB;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public interface ICustomerService
    {
        List<Customers> GetCustomers();
    }
}

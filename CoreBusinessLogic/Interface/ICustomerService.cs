using CoreDataLayer.ModelsDB;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Interface
{
    public interface ICustomerService
    {
        List<Customers> GetCustomers();
        Task AddCustomer(CustomersModel customersModel);
        Task<Customers> FindCustomer(int? Cid);
        Task UpdateCustomer(Customers customers);
        bool CustomersExists(int CId);
    }
}

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
        Task<CustomersModel> FindCustomer(int? Cid);
        Task UpdateCustomer(CustomersModel customers);
        
        bool CustomersExists(int CId);
        Task DeleteConfirmedCustomer(int id);
    }
}

using CoreBusinessLogic.Interface;
using CoreDataLayer.Interface;
using CoreDataLayer.ModelsDB;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreBusinessLogic.Implementation
{
    public class CustomerService : ICustomerService
    {
        public IRepository<Customers> _CustomerRepository;
        public CustomerService(IRepository<Customers> repository)
        {
            _CustomerRepository = repository;
        }

        public List<Customers> GetCustomers()
        {
            return _CustomerRepository.GetAll().ToList();
        }
    }
}

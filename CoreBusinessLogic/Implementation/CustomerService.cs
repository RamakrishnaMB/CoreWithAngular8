using AutoMapper;
using CoreBusinessLogic.AutoMapperSettings;
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
        private readonly IMapper mapper;

        public CustomerService(IRepository<Customers> repository)
        {
            _CustomerRepository = repository;
            this.mapper = AutoMapperConfig.mapper;
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> test1 = _CustomerRepository.GetAll().ToList();
            var test = this.mapper.Map<List<CustomersModel>>(test1);
            return _CustomerRepository.GetAll().ToList();
        }
    }
}

using AutoMapper;
using CoreBusinessLogic.AutoMapperSettings;
using CoreBusinessLogic.Interface;
using CoreDataLayer.Interface;
using CoreDataLayer.ModelsDB;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _CustomerRepository.GetAll().ToList();
        }

        public async Task AddCustomer(CustomersModel customersModel)
        {
            Customers customers = this.mapper.Map<Customers>(customersModel);
            _CustomerRepository.Add(customers);
            await _CustomerRepository.SaveChangesAsync();
        }

        public async Task<Customers> FindCustomer(int? Cid)
        {
            var customer = await _CustomerRepository.FindAsync(Cid);
            return customer;
        }
    }
}

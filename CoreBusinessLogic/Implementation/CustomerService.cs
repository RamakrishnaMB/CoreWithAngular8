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


        public async Task UpdateCustomer(CustomersModel customersModel)
        {
            Customers customers = this.mapper.Map<Customers>(customersModel);
            _CustomerRepository.Update(customers);
            await _CustomerRepository.SaveChangesAsync();
        }

        public async Task<CustomersModel> FindCustomer(int? Cid)
        {
            var customerdb = await _CustomerRepository.FindAsync(Cid);
            CustomersModel customersModel = this.mapper.Map<CustomersModel>(customerdb);
            return customersModel;
        }

        public async Task DeleteConfirmedCustomer(int Cid)
        {
            var customerdb = await _CustomerRepository.FindAsync(Cid);
            _CustomerRepository.Delete(customerdb);
            await _CustomerRepository.SaveChangesAsync();
        }


        public bool CustomersExists(int Cid)
        {
            var Cust = _CustomerRepository.GetById(Cid);
            if (Cust != null)
                return true;
            else
                return false;
        }
    }
}

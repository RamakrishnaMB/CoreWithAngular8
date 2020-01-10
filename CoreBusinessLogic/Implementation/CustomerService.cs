using AutoMapper;
using CoreBusinessLogic.AutoMapperSettings;
using CoreBusinessLogic.Interface;
using CoreDataLayer.Interface;
using CoreDataLayer.ModelsDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<HttpResponseMessage> UploadProfilePicAsync(IFormFile fromFile)
        {

            string Baseurl = "http://localhost:65363/";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                byte[] data;
                using (var br = new BinaryReader(fromFile.OpenReadStream()))
                    data = br.ReadBytes((int)fromFile.OpenReadStream().Length);
                ByteArrayContent bytes = new ByteArrayContent(data);
                MultipartFormDataContent multiContent = new MultipartFormDataContent
                {
                    { bytes, "file", fromFile.FileName }
                };

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
               // HttpResponseMessage Res = await client.PostAsync("api/Employee/GetAllEmployees", multiContent);
                var result = await client.PostAsync("api/FileUploadServer/upload", multiContent);
                return result;
            }
        }
    }
}

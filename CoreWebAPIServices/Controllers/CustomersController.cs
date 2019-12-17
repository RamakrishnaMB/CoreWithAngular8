using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoreBusinessLogic.Interface;
using CoreDataLayer.ModelsDB;
using CoreWebAPIServices.Utilites;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json.Linq;

namespace CoreWebAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;


        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetFeeDetails()
        {
            //var DeviceId = ((JObject)jObject).GetValue("deviceId", StringComparison.OrdinalIgnoreCase).Value<string>();
            //var GradeId = ((JObject)jObject).GetValue("gradeId", StringComparison.OrdinalIgnoreCase).Value<int>();
            List<Customers> customers = this.customerService.GetCustomers();
            APIMessage aPIMessage = new APIMessage { StatusCode = (int)HttpStatusCode.OK, StatusMessage = "Sucess great !!", Data = customers };
            //method: post, url : http://localhost:58272/api/customers/getdetails , Request body: { userId:10,deviceId:11,gradeId:22} , Content-Type: application/json            
            return StatusCode((int)HttpStatusCode.OK, customers);
        }


        [HttpGet]
        [Route("GetCustomerbyIDAsync/{Cid}")]
        public async Task<IActionResult> GetCustomerbyIDAsync(int Cid)
        {
            //   int Cid = ((JObject)jObject).GetValue("Cid", StringComparison.OrdinalIgnoreCase).Value<int>();
            CustomersModel customers = await this.customerService.FindCustomer(Cid);
            // APIMessage aPIMessage = new APIMessage { StatusCode = (int)HttpStatusCode.OK, StatusMessage = "Sucess great !!", Data = customers };
            return StatusCode((int)HttpStatusCode.OK, customers);
        }

        [HttpPost]
        [Route("AddCustomerAsync")]
        public async Task<IActionResult> AddCustomerAsync([FromBody][Bind("Name,Telephone")] CustomersModel customer)
        {
            if (ModelState.IsValid)
            {
                await this.customerService.AddCustomer(customer);
            }
            return StatusCode((int)HttpStatusCode.Created, customer);
        }


        [HttpPut]
        [Route("UpdateCustomerAsync")]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody][Bind("Name,Telephone,Email")] CustomersModel customer)
        {
            if (ModelState.IsValid)
            {
                 await this.customerService.UpdateCustomer(customer);
            }
            return StatusCode((int)HttpStatusCode.OK, customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{Cid}")]
        public async Task<IActionResult> DeleteCustomer(int Cid)
        {
            await this.customerService.DeleteConfirmedCustomer(Cid);

            return StatusCode((int)HttpStatusCode.OK);
        }


    }
}
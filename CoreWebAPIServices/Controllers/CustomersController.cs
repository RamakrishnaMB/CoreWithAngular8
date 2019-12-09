using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using CoreBusinessLogic.Interface;
using CoreDataLayer.ModelsDB;
using CoreWebAPIServices.Utilites;
using Microsoft.AspNetCore.Mvc;

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
            //http://localhost:59881/api/FeeDetailsAPI/GetFeeDetails
            //var DeviceId = ((JObject)jObject).GetValue("deviceId", StringComparison.OrdinalIgnoreCase).Value<string>();
            //var GradeId = ((JObject)jObject).GetValue("gradeId", StringComparison.OrdinalIgnoreCase).Value<int>();
            List<Customers> customers = this.customerService.GetCustomers();

            APIMessage aPIMessage = new APIMessage { StatusCode = (int)HttpStatusCode.OK, StatusMessage = "Sucess great !!", Data = customers };

            //method: post, url : http://localhost:58272/api/customers/getdetails , Request body: { userId:10,deviceId:11,gradeId:22} , Content-Type: application/json            



            return StatusCode(200, customers);


        }
    }
}
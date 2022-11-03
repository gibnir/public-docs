using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiJson.Models;
using WebApiJson.Server;

namespace WebApiJson.Controllers
{
    //[Route("[controller]")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("Customer/GetCustomerListFromJson")]
        // GET: api/Customer
        public List<Customer> GetCustomerListFromJson()
        {
            return BL.Self().GetCustomerListFromJson();
        }
        /*
        For Example
        {
            "ContractId": 200004,
            "CustID": 200000,
            "ContractType": "Type2",
            "LastName": "L200004",
            "FirstName": "N200004"
        }
             */
        [HttpPost]
        [Route("Customer/AddContractToCustomerByID")]
        // POST: api/Customer
        public bool AddContractTocustomerByID([FromBody]Contract contract)
        {
            return BL.Self().AddContractTocustomerByID(contract, contract.CustID);
        }

        /*
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
        */
    }
}

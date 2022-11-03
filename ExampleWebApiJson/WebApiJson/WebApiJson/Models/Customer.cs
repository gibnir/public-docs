using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiJson.Models
{
    /// <summary>
    /// Customer class contain list of contracts.
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Contract> ContractList { get; set; }
    }

    public class Contract {
        public int ContractId { get; set; }
        public int CustID { get; set; }
        public string ContractType { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

    }
}
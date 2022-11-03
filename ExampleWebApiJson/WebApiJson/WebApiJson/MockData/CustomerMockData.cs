using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiJson.Models;

namespace WebApiJson.MockData
{
    public class CustomerMockData
    {
        public List<Customer> CreateMockCustomerData() {
            List<Customer> CustomerList = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 100000,
                    CustomerName = "Cust100000",
                    ContractList = {
                        new Contract {
                            ContractId = 100001,
                            CustID = 100000,
                            ContractType = "Type1",
                            FirstName = "N100001",
                            LastName = "L100001"
                        },
                        new Contract {
                            ContractId = 100002,
                            CustID = 100000,
                            ContractType = "Type1",
                            FirstName = "N100002",
                            LastName = "L100002"
                        },
                        new Contract {
                            ContractId = 100003,
                            CustID = 100000,
                            ContractType = "Type1",
                            FirstName = "N100003",
                            LastName = "L100003"
                        }
                    }
                },
                new Customer
                {
                    CustomerID = 200000,
                    CustomerName = "Cust200000",
                    ContractList = {
                        new Contract {
                            ContractId = 200001,
                            CustID = 200000,
                            ContractType = "Type2",
                            FirstName = "N200001",
                            LastName = "L200001"
                        },
                        new Contract {
                            ContractId = 200002,
                            CustID = 200000,
                            ContractType = "Type2",
                            FirstName = "N200002",
                            LastName = "L200002"
                        },
                        new Contract {
                            ContractId = 200003,
                            CustID = 200000,
                            ContractType = "Type2",
                            FirstName = "N200003",
                            LastName = "L200003"
                        }
                    }
                },
                new Customer
                {
                    CustomerID = 300000,
                    CustomerName = "Cust300000",
                    ContractList = {
                        new Contract {
                            ContractId = 300001,
                            CustID = 300000,
                            ContractType = "Type3",
                            FirstName = "N300001",
                            LastName = "L300001"
                        },
                        new Contract {
                            ContractId = 300002,
                            CustID = 300000,
                            ContractType = "Type2",
                            FirstName = "N300002",
                            LastName = "L300002"
                        },
                        new Contract {
                            ContractId = 300003,
                            CustID = 300000,
                            ContractType = "Type2",
                            FirstName = "N300003",
                            LastName = "L300003"
                        }
                    }
                }
            };

            return CustomerList;
        }
    }
}
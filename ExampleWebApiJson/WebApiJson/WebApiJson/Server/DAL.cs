using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApiJson.Models;

namespace WebApiJson.Server
{
    public class DAL
    {
        public readonly string JsonFilePath = @"C:\data\Learn\LearnCSharp\asp.Net framework\WebApiJson\WebApiJson\App_Data\CustomerData.json";

        #region Singleton

        private DAL() { }

        private static DAL mInstance;
        
        public static DAL Self()
        {
            if (mInstance == null)
            {
                mInstance = new DAL();
            }
            return mInstance;
        }

        #endregion Singleton

        #region Customer/Contract data

        #region MockData

        #endregion MockData

        #region DataFromJson

        public List<Customer> GetCustomerListFromJson() {
            List<Customer> customers = new List<Customer>();

            using (StreamReader reader = new StreamReader(JsonFilePath)) {
                string json = reader.ReadToEnd();
                // customers = JsonSerializer.Deserialize<List<Customer>>(json);
                customers = JsonConvert.DeserializeObject<List<Customer>>(json); // Serializer.Deserialize<List<Customer>>(json);
            }

            return customers;
        }

        public bool AddContractTocustomerByID(Contract contract, int customerID) {
            JsonSerializer serializer = new JsonSerializer();

            List<Customer> customers = GetCustomerListFromJson();

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustomerID == contract.CustID)
                {
                    customers[i].ContractList.Add(contract);
                }
            }

            using (StreamWriter sw = new StreamWriter(JsonFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, customers);
            }


            return true;
        }

        #endregion DataFromJson
        
        #region Data
        #endregion Data

        #endregion Customer/Contract data

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion
    }
}
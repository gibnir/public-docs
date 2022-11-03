using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiJson.Models;

namespace WebApiJson.Server
{
    public class BL
    {

        #region Singleton

        private BL() { }

        private static BL mInstance;

        public static BL Self()
        {
            if (mInstance == null)
            {
                mInstance = new BL();
            }
            return mInstance;
        }

        #endregion Singleton

        #region DataFromJson

        public List<Customer> GetCustomerListFromJson()
        {
            return DAL.Self().GetCustomerListFromJson();
        }

        public bool AddContractTocustomerByID(Contract contract, int customerID)
        {
            return DAL.Self().AddContractTocustomerByID(contract, customerID);
        }

        #endregion DataFromJson
    }
}
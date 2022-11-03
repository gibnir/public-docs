using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiJson.Models
{
    /*
    Equity is the amount of money that a company's owner has put into it or owns.
    On a company's balance sheet,
    the difference between its liabilities and assets shows how much equity the company has.
    The share price or a value set by valuation experts or investors
    is used to figure out the equity value.
    */
    public class Equity
    {
        public Guid EquityID { get; set; }
        public List<Option> OptionList { get; set; }

        public class Option {
            public Guid OptionID { get; set; }
        }
    }
}
using FlooringMastery.Data;
using FlooringMastery.Data.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "OrderTest":
                    return new OrderManager(new AddOrderTestRepository("Orders_06012013.txt"));
                case "TestRepo":
                    return new OrderManager(new TestRepository());
                //case "TaxesTest":
                //    return new OrderManager(new TaxesTestRepository("Taxes.txt"));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
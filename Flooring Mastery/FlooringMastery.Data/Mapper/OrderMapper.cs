using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.Data
{
    public class OrderMapper
    {
        public static Orders ToOrder(string row, DateTime date)
        {
            Orders orders = new Orders();
            string[] field = row.Split(',');
            orders.OrderNumber = int.Parse(field[0]); //assign data to the object members
            orders.CustomerName = field[1];
            orders.State = field[2];
            orders.TaxRate = decimal.Parse(field[3]);
            orders.ProductType = field[4];
            orders.Area = decimal.Parse(field[5]);
            orders.CostPerSquareFoot = decimal.Parse(field[6]);
            orders.LaborCostPerSquareFoot = decimal.Parse(field[7]);
            orders.OrderDate = date;

            return orders;
        }

        public static string toStringCSV(Orders orders)
        {
            string row = $"{orders.OrderNumber},{orders.CustomerName},{orders.State},{orders.TaxRate},{orders.ProductType},{orders.Area},{orders.CostPerSquareFoot},{orders.LaborCostPerSquareFoot},{orders.MaterialCost},{orders.LaborCost},{orders.Tax},{orders.Total}";

            return row;
                
        }

        public static Taxes ToTaxes(string row)
        {
            Taxes taxes = new Taxes();
            string[] field = row.Split(',');
            taxes.StateAbbreviation = field[0];
            taxes.StateName = field[1];
            taxes.TaxRate = decimal.Parse(field[2]);

            return taxes;
        }

        public static string ToTaxesCSV(Taxes taxes)
        {
            string row = $"{taxes.StateAbbreviation},{taxes.StateName},{taxes.TaxRate}";

            return row;
        }

        public static Products ToProducts(string row)
        {
            Products products = new Products();
            string[] field = row.Split(',');
            products.ProductType = field[0];
            products.CostPerSquareFoot = decimal.Parse(field[1]);
            products.LaborCostPerSquareFoot = decimal.Parse(field[2]);

            return products;
        }

        public static string ToProductsCSV(Products products)
        {
            string row = $"{products.ProductType},{products.CostPerSquareFoot},{products.LaborCostPerSquareFoot}";

            return row;
        }
    }
}
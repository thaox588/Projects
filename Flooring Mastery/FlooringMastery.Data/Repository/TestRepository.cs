using FlooringMastery.Models;
using FlooringMastery.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repository
{
    public class TestRepository : ICRUD
    {

        static DateTime date = new DateTime(2013, 06, 01);


        private Orders _filePath = new Orders()
        {
            OrderDate = date,
            OrderNumber = 1,
            CustomerName = "Yeng",
            State = "PA",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M
        };

        private Orders _filePath2 = new Orders()
        {
            OrderDate = date,
            OrderNumber = 4,
            CustomerName = "Sally",
            State = "MI",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M
        };
        List<Orders> orders;

        public TestRepository()
        {
            orders = new List<Orders>()
            {
            _filePath,
            _filePath2
            };
        }


        public Orders Create(DateTime date, Orders order)
        {
            orders.Add(order);
            return order;
        }

        public bool Delete(Orders order)
        {

            return orders.RemoveAll(o => o.OrderNumber == order.OrderNumber) == 1;


        }

        public List<Orders> LoadOrders(DateTime date)
        {
            return orders;
        }

        public Orders RemoveEditLoadOrder(DateTime date, string input)
        {
            return orders.FirstOrDefault(o => o.OrderNumber.ToString() == input);
        }

        public void SaveAllOrders(DateTime date, List<Orders> order)
        {
            this.orders = order;
        }

        public bool Update(Orders newOrdersInfo)
        {
            bool result = Delete(newOrdersInfo);
            Create(date, newOrdersInfo);
            return result;
        }
    }
}

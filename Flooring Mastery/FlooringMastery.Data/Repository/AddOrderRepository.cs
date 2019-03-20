using FlooringMastery.Models;
using FlooringMastery.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class AddOrderTestRepository : ICRUD
    {
        protected List<Orders> getOrders = new List<Orders>();
        private string _orderPath; //field
        DateTime date = new DateTime();

        public AddOrderTestRepository(string filePath)
        {
            _orderPath = filePath; //we could use it to list, add, edit, delete
        }

        public Orders Create(DateTime date, Orders order)//create datetime
        {
            getOrders = LoadOrders(date);

            int number = 0;
            foreach (Orders o in getOrders)
            {
                if (o.OrderNumber > number)
                {
                    number = o.OrderNumber;
                }
            }
            number = number + 1;

            order.OrderDate = date;
            order.OrderNumber = number;
            getOrders.Add(order);
            SaveAllOrders(date, getOrders);
            return order;
        }


        public bool Update(Orders newOrdersInfo)
        {
            getOrders = LoadOrders(newOrdersInfo.OrderDate);

            for (int i = 0; i < getOrders.Count; i++)
            {
                if (getOrders[i].OrderNumber == newOrdersInfo.OrderNumber)
                {
                    getOrders[i] = newOrdersInfo;
                    SaveAllOrders(newOrdersInfo.OrderDate, getOrders);
                    return true;
                }
            }
            return false;
        }

        public bool Delete(Orders order)
        {
            getOrders = LoadOrders(order.OrderDate);
            if (getOrders != null)
            {
                getOrders.RemoveAll(orderInfo => orderInfo.OrderNumber == order.OrderNumber);
                SaveAllOrders(order.OrderDate, getOrders);
                return true;
            }
            return false;
        }

        public Orders RemoveEditLoadOrder(DateTime date, string input)
        {
            List<Orders> results = new List<Orders>();

            _orderPath = "Orders_" + date.Month.ToString("d2") + date.Day.ToString("d2") + date.Year + ".txt";
            
            using (StreamReader sr = new StreamReader(_orderPath))
            {
                string row = sr.ReadLine();
                while ((row = sr.ReadLine()) != null)
                {
                    Orders c = OrderMapper.ToOrder(row, date);
                    results.Add(c);
                }
            }
            
            return results.FirstOrDefault(a => a.OrderNumber.ToString() == input);
        }

        public List<Orders> LoadOrders(DateTime date)
        {
            List<Orders> results = new List<Orders>();

            _orderPath = "Orders_" + date.Month.ToString("d2") + date.Day.ToString("d2") + date.Year + ".txt";

            if(!File.Exists(_orderPath))
            {
                File.Create(_orderPath).Close();

                return results;
            }

            using (StreamReader sr = new StreamReader(_orderPath))
            {
                string row = sr.ReadLine();
                while ((row = sr.ReadLine()) != null)
                {
                    Orders c = OrderMapper.ToOrder(row, date);
                    results.Add(c);
                }
            }
            return results;
        }

        public void SaveAllOrders(DateTime date, List<Orders> orders)
        {
            _orderPath = "Orders_" + date.Month.ToString("d2") + date.Day.ToString("d2") + date.Year + ".txt";

            using (StreamWriter sw = new StreamWriter(_orderPath))
            {
                sw.WriteLine("OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LaborCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total");
                foreach (Orders order in orders)
                {                    
                    sw.WriteLine(OrderMapper.toStringCSV(order));
                }

            }
        }
    }
}

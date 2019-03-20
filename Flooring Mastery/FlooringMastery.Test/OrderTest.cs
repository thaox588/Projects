using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Data.Repository;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Test
{
    [TestFixture]
    public class OrderTest
    {
        DateTime date = new DateTime();
        Orders order = new Orders();
        TestRepository repo = new TestRepository();
        OrderManager manager = new OrderManager(new TestRepository());

        [TestCase(1, true)]
        [TestCase(3, false)]
        public void ManagerDeleteTest(int orderNumber, bool expected)
        {

            Orders testOrder = new Orders()
            {
                OrderDate = new DateTime(2013, 06, 01),
                OrderNumber = orderNumber,
                CustomerName = "Yeng",
                State = "PA",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };
            
            RemoveOrderResponse response = manager.DeleteOrder(testOrder);

            Assert.AreEqual(expected, response.Success);
            if(response.Success)
            {
                manager.AddOrder(new DateTime(2013, 06, 01), testOrder);
            }
        }

        
        public void ManagerAddTest(int orderNumber, bool expected)
        {
            DateTime date = new DateTime(2013, 06, 01);

            repo.Create(date, order);

            OrderAddResponse response = manager.AddOrder(date, order);

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(date, response.Order.OrderDate);
            Assert.AreEqual(order.OrderNumber, response.Order.OrderNumber);
            Assert.AreEqual(order.CustomerName, response.Order.CustomerName);
            
            
            
        }

        [TestCase(1, "Yeng", true)]
        [TestCase(10, "King", false)]
        public void ManagerEditTest(int orderNumber, string cutomerName, bool expected)
        {
            List<Orders> orders = repo.LoadOrders(date);

            Orders testOrder = new Orders()
            {
                OrderDate = new DateTime(2013, 06, 01),
                OrderNumber = orderNumber,
                CustomerName = cutomerName,
                State = "PA",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };

                EditOrderResponse response = manager.EditOrder(testOrder);

                Assert.AreEqual(expected, response.Success);
        }

        
        public void ManagerLoadTest(int orderNumber, string cutomerName, bool expected)
        {
            DateTime date = new DateTime(2013, 06, 01);

            OrderLookupResponse response = manager.OrderLookup(date);

            Assert.AreEqual(date, response.Orders.FirstOrDefault(o => o.OrderDate == date).OrderDate);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Orders);
        }


        [Test]
        public void DisplayTestRepo()
        {

            List<Orders> orders = repo.LoadOrders(date);

            Assert.AreEqual(3, orders.Count);

            Orders check = orders[1];

            Assert.AreEqual(4, check.OrderNumber);
            Assert.AreEqual("Sally", check.CustomerName);
            Assert.AreEqual("MI", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.875M, check.Tax);
            Assert.AreEqual(1051.875M, check.Total);

        }

        [Test]
        public void OrderCorrectFormat()
        {

            {
                order.OrderNumber = 1;
                order.CustomerName = "Wise";
                order.State = "OH";
                order.TaxRate = 6.25M;
                order.ProductType = "Wood";
                order.Area = 100.00M;
                order.CostPerSquareFoot = 5.15M;
                order.LaborCostPerSquareFoot = 4.75M;

            }
            string expected = "1,Wise,OH,6.25,Wood,100.00,5.15,4.75,515.0000,475.0000,61.87500000,1051.87500000";
            //Act
            string actual = OrderMapper.toStringCSV(order);
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void CanAddToFile()
        {
            repo.Create(date, order);

            List<Orders> orders = repo.LoadOrders(date);

            Assert.AreEqual(3, orders.Count);

            Orders check = orders[0]; //checking to see if index [0] is equal to the data 

            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("Yeng", check.CustomerName);
            Assert.AreEqual("PA", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.875M, check.Tax);
            Assert.AreEqual(1051.875M, check.Total);

            repo.Delete(order);
        }

        [Test]
        public void CanDeleteFile()
        {

            repo.Delete(order);

            List<Orders> orders = repo.LoadOrders(date);

            Assert.AreEqual(2, orders.Count);

            Orders check = orders[1];

            Assert.AreEqual(4, check.OrderNumber);
            Assert.AreEqual("Sally", check.CustomerName);
            Assert.AreEqual("MI", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.875M, check.Tax);
            Assert.AreEqual(1051.875M, check.Total);

            repo.Create(date, order);
        }

        [Test]
        public void CanEditFile()
        {
            List<Orders> orders = repo.LoadOrders(date);

            Orders editOrder = orders.FirstOrDefault(o => o.OrderNumber == 1);
            editOrder.CustomerName = "KingKong";
            editOrder.State = "OH";

            repo.Update(order);

            orders = repo.LoadOrders(date);
            Orders check = orders.FirstOrDefault(o => o.OrderNumber == 1);

            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("KingKong", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.875M, check.Tax);
            Assert.AreEqual(1051.875M, check.Total);

        }

        [Test]
        public void CanLoadData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            DateTime date = new DateTime(2013, 06, 01);

            List<Orders> orders = repo.LoadOrders(date);
        
            Assert.IsNotNull(orders);
            Assert.AreEqual(date, orders.FirstOrDefault(o => o.OrderDate == date).OrderDate);
        }
    }
}

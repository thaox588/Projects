using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflow
{
    public class AddOrdersWorkflow
    {
        ConsoleIO IO = new ConsoleIO();
        List<Orders> getOrders = new List<Orders>();
        DateTime date = new DateTime();

        AddOrderTestRepository repo = new AddOrderTestRepository("");

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Add an order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Orders orders = new Orders();

            date = IO.GetDateTimeFromUser();
            Console.Clear();
            orders.CustomerName = IO.GetNameFromUser("Name: ");
            Console.Clear();
            orders.State = IO.DisplayStateFromUser("State: ");
            Console.Clear();
            orders.ProductType = IO.DisplayProductFromUser("Product Type: ");
            Console.Clear();
            orders.Area = IO.GetDecimalFromUser("Area: ");
            orders = manager.Calculate(orders);

            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("This is your order");
            IO.DisplayOrder(orders);
            Console.WriteLine();

            if (IO.GetYesNoAnswerFromUser("Add the order") == "Y")
            {
                OrderAddResponse response = manager.AddOrder(date, orders);
                if (response.Success)
                {
                    Console.WriteLine("Order has been added");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(response.Message);
                }
            }
            else
            {
                Console.WriteLine("Order Cancelled");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}

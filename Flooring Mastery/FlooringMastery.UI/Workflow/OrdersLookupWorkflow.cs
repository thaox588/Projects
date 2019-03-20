using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.UI
{
    public class OrdersLookupWorkflow
    {
        ConsoleIO IO = new ConsoleIO();

        public void Execute()
        {
            Orders orders = new Orders();

            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            while (true)
            {
                Console.Write("Enter an order date:  ");

                string userinput = "MM/DD/YYYY";
                DateTime date = DateTime.Parse("06/01/2013");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Incorrect date format, ex: {0}", userinput);
                    continue;
                }
                OrderLookupResponse response = manager.OrderLookup(date);

                if (response.Success)
                {
                    IO.DisplayOrderDetails(response.Orders);
                }
                else
                {
                    response.Success = false;
                    Console.WriteLine("This order doesn't exist!");
                    Console.WriteLine(response.Message);
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }

        
    }
}
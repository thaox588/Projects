using FlooringMastery.UI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.UI
{
    public class Menu
    {

        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Program");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");

                Console.Write("\nEnter your selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        OrdersLookupWorkflow ordersLookup = new OrdersLookupWorkflow();
                        ordersLookup.Execute();
                        break;
                    case "2":
                        AddOrdersWorkflow addOrders = new AddOrdersWorkflow();
                        addOrders.Execute();
                        break;
                    case "3":
                        EditOrdersWorkflow editOrders = new EditOrdersWorkflow();
                        editOrders.Execute();
                        break;
                    case "4":
                        RemoveOrdersWorkflow removeOrders = new RemoveOrdersWorkflow();
                        removeOrders.Execute();
                        break;
                    case "5":
                        return;
                }
            }

        }
    }
}
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. use responses between manager and workflow

//2. write more test, BLL AND MANAGER

//4. create test repo and file repo

//3. use interface test repo. and file repo

namespace FlooringMastery.UI.Workflow
{
    public class EditOrdersWorkflow
    {
        //public int orderNumber = 0;
        ConsoleIO IO = new ConsoleIO();
        DateTime date = new DateTime();
        Taxes taxes = new Taxes();

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Orders order = new Orders();

            bool again = true;

            while (again)
            {
                date = IO.GetDateTimeFromUserForRemoveEdit();

                List<Orders> orders = manager.OrderLookup(date).Orders;
                order = IO.GetOrderNumber(orders);
                IO.DisplayOrder(order);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                

                Console.Clear();
                Console.WriteLine("Press enter to keep.");
                Console.WriteLine("Press any key to enter a name.");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.Write($"Enter customer name ({order.CustomerName}): ");
                var name = Console.ReadLine();
                while (true)
                {
                    if (name == "")
                    {
                        break;
                    }
                    else if (name != "")
                    {
                        Console.Clear();
                        order.CustomerName = IO.GetNameFromUser("Enter name: ");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.Clear();
                Console.WriteLine("Press enter to keep.");
                Console.WriteLine("Press any key to enter a state.");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.Write($"State ({order.State}): ");
                var stateName = Console.ReadLine();
                while (true)
                {
                    if (stateName == "")
                    {
                        break;
                    }
                    else if (stateName != "")
                    {
                        Console.Clear();
                        order.State = IO.DisplayStateFromUser("");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.Clear();
                Console.WriteLine("Press enter to keep.");
                Console.WriteLine("Press any key to enter a product type.");
                Console.WriteLine(ConsoleIO.SeparatorBar);

                Console.Write($"ProductType ({order.ProductType}): ");
                var productName = Console.ReadLine();
                while (true)
                {
                    if (productName == "")
                    {
                        break;
                    }
                    else if (productName != "")
                    {
                        Console.Clear();
                        order.ProductType = IO.DisplayProductFromUser("");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Clear();
                Console.WriteLine("Press enter to keep.");
                Console.WriteLine("Press any key to enter an area.");
                Console.WriteLine(ConsoleIO.SeparatorBar);

                Console.Write($"Area ({order.Area}): ");
                var area = Console.ReadLine();
                while (true)
                {
                    if (area == "")
                    {
                        break;
                    }
                    else if (area != "")
                    {
                        Console.Clear();
                        order.Area = IO.GetDecimalFromUser("Area: ");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.Clear();
                IO.DisplayOrder(order);


                Console.WriteLine(ConsoleIO.SeparatorBar);
                if (order != null)
                {
                    if (IO.GetYesNoAnswerFromUser("Are you sure you want to remove this order? ") == "Y")
                    {
                        EditOrderResponse editResponse = manager.EditOrder(order);
                        if (editResponse.Success)
                        {
                            Console.WriteLine("Order has been edited");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            again = false;
                        }
                        else
                        {
                            Console.WriteLine(editResponse.Message);
                            again = false;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Edit Cancelled");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        again = false;
                    }
                }
                
            }

        }
    }
}
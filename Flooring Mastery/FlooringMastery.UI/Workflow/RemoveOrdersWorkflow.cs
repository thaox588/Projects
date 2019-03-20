using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflow
{
    public class RemoveOrdersWorkflow
    {
        public int orderNumber = 0;
        ConsoleIO IO = new ConsoleIO();
        DateTime date = new DateTime();

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);


            Orders order = new Orders();

            bool again = true;

            while (again)
            {
                date = IO.GetDateTimeFromUserForRemoveEdit();
                List<Orders> orders = manager.OrderLookup(date).Orders;
                order = IO.GetOrderNumber(orders);
                if (order != null)
                {
                    IO.DisplayOrder(order);
                    if (IO.GetYesNoAnswerFromUser("Are you sure you want to remove this order? ") == "Y")
                    {
                        RemoveOrderResponse response = manager.DeleteOrder(order);
                        if (response.Success)
                        {
                            Console.WriteLine("Order has been removed");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            again = false;
                        }
                        else
                        {
                            Console.WriteLine("Remove failure!");
                            Console.WriteLine(response.Message);
                            Console.ReadKey();
                            again = false;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Order not cancelled");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        again = false;
                    }
                }
            }

        }
    }
}

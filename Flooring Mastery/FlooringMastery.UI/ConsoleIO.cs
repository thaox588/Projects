using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Data.Repository;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "===========================================================";
        public const string LineFormat = "{0, -15} {1, -15} {2, -15} {3, -15}";
        public const string LineFormat2 = "{0, -15} {1, -20} {2, -20}";
        public const string LineFormat3 = "{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5 -15} {6, -15} {7, -15} {8, -15}";

        public Orders orders = new Orders();
        public DateTime dateTime = new DateTime();
        public string states = "";
        public string name = "";
        public string productType = "";
        public decimal area = 0;
        public Taxes taxes = new Taxes();
        public Products products = new Products();
        AddOrderTestRepository repo = new AddOrderTestRepository("");
        OrderManager manager = OrderManagerFactory.Create();

        public void PrintOrderListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(LineFormat, "Name", "State", "Product", "Area");
            Console.WriteLine(SeparatorBar);
        }

        public void DisplayOrder(Orders item)
        {

            Console.WriteLine(SeparatorBar);

            Console.WriteLine($"Order number: {item.OrderNumber}");
            Console.WriteLine($"Name: {item.CustomerName}");
            Console.WriteLine($"State: {item.State}");
            Console.WriteLine($"Product: {item.ProductType}");
            Console.WriteLine($"Materials: {item.MaterialCost}");
            Console.WriteLine($"Labor: {item.LaborCost}");
            Console.WriteLine($"Tax: {item.Tax}");
            Console.WriteLine($"Total: {item.Total}");

        }

        public void DisplayOrderDetails(List<Orders> orders)
        {
            foreach (var item in orders)
            {
                DisplayOrder(item);
            }
        }

        public DateTime GetDateTimeFromUserForRemoveEdit()
        {
            bool again = true;
            DateTime date = new DateTime();

            while (again)
            {
                Console.Write("Enter an order date:  ");

                string userinput = "MM/DD/YYYY";
                date = DateTime.Parse("06/01/2013");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Incorrect date format, ex: {0}", userinput);
                    continue;
                }
                else
                {
                    again = false;
                }
            }
            return date;
        }

        public DateTime GetDateTimeFromUser()
        {
            bool again = true;
            DateTime date = new DateTime();

            while (again)
            {
                Console.Write("Enter an order date:  ");

                string userinput = "MM/DD/YYYY";
                date = DateTime.Parse("06/01/2013");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Incorrect date format, ex: {0}", userinput);
                    continue;
                }
                if (date <= DateTime.Now)
                {
                    Console.WriteLine("The date needs to be a future date.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    again = false;
                }
            }
            return date;
        }

        public void DisplayLookUpOrder(Orders orders)
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an order");
            Console.WriteLine(SeparatorBar);

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
                    DisplayOrderDetails(response.Orders);
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

        public string GetStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                if (input != "Y" && input != "N")
                {
                    Console.WriteLine("Please input Y for yes or N for no.");
                    continue;
                }
                else
                {
                    return input;
                }
            }
        }

        public decimal GetDecimalFromUser(string prompt)
        {
            decimal output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 100)
                    {
                        Console.WriteLine("Minimum order size is 100 square feet");
                        continue;
                    }
                    return output;
                }
            }
        }

        public string GetNameFromUser(string name)
        {
            while (true)
            {
                Console.Write(name);
                string input = Console.ReadLine();
                bool result = input.All(c => Char.IsLetterOrDigit(c) || c == ',' || c == '.' || c == ' ');

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter a valid name");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    continue;
                }
                else if (result == false)
                {
                    Console.WriteLine("You must enter a valid name ");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    continue;
                }
                else
                {
                    result = true;
                    return input;
                }
            }
        }

        public string DisplayStateFromUser(string input)
        {
            bool again = true;

            while (again)
            {
                List<Taxes> tax = manager.GetListTaxes();

                foreach (var item in tax)
                {
                    Console.WriteLine($"{item.StateAbbreviation},{item.StateName}");
                }

                Console.WriteLine("");
                Console.Write("State: ");
                input = Console.ReadLine().ToUpper();

                foreach (var taxes in tax)
                {
                    if (taxes.StateAbbreviation == input || taxes.StateName == input)
                    {
                        again = false;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Clear();
            }
            return input;
        }


        public string DisplayProductFromUser(string input)
        {
            bool again = true;

            while (again)
            {
                List<Products> products = ProductsRepository.LoadProducts();//change

                Console.WriteLine(SeparatorBar);
                Console.WriteLine(LineFormat2, "Product Type", "CostPerSquareFoot", "LaborCostPerSquareFoot");
                Console.WriteLine(SeparatorBar);

                foreach (var item in products)
                {
                    Console.WriteLine(LineFormat2, item.ProductType, item.CostPerSquareFoot, item.LaborCostPerSquareFoot);
                }

                Console.WriteLine();
                Console.Write("Product: ");
                input = Console.ReadLine();

                foreach (var item in products)
                {
                    if (item.ProductType == input)
                    {
                        again = false;
                    }
                }
                Console.Clear();
            }
            return input;
        }

        public Orders GetOrderNumber(List<Orders> orders)
        {
            bool again = true;
            do
            {
                Console.Write("Enter an order number: ");
                int orderNumber = 0;
                if (!int.TryParse(Console.ReadLine(), out orderNumber))
                {
                    Console.WriteLine("Wrong format");
                    Console.ReadKey();
                    continue;
                }
                if (orderNumber < 1)
                {
                    Console.WriteLine("Can't be 0");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
                }
            } while (again);
            return null;
        }

    }
}
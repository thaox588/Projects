using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repository
{
    public class ProductsRepository
    {
        public static List<Products> LoadProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                using (StreamReader sr = new StreamReader("Products.txt"))
                {
                    string row = sr.ReadLine();
                    while ((row = sr.ReadLine()) != null)
                    {
                        Products c = OrderMapper.ToProducts(row);
                        products.Add(c);
                    }

                }
            }
            catch (Exception)
            {

                Console.WriteLine("This is not a valid product type");
            }
            return products;
            
        }
    }
}

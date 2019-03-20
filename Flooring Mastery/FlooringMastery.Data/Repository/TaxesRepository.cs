using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public static class TaxesRepository 
    {
        public static List<Taxes> LoadTaxes()
        {
            List<Taxes> results = new List<Taxes>();
            try
            {
                using (StreamReader sr = new StreamReader("Taxes.txt")) //StreamReader is to read one line at a time
                {

                    string row = sr.ReadLine();
                    while ((row = sr.ReadLine()) != null) //sr.Readline is to read the line and put it back on row to see if it's not null
                    {
                        Taxes c = OrderMapper.ToTaxes(row);
                        results.Add(c);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("This is not a valid date");
            }

            return results;
        }

    }
}

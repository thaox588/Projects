using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.Models
{
    public class Taxes
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
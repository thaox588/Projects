using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.Models
{
    public class Products
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
    }
}
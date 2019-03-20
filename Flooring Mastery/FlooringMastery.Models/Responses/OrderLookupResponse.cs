using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.Models
{
    public class OrderLookupResponse : Response
    {
        public List<Orders> Orders { get; set; } 
    }
}
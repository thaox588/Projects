﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class ProductResponse : Response
    {
        public List<Products> GetProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class OrderAddResponse : Response
    {
        public Orders Order { get; set; }
    }
}

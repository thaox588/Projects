using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.Models
{
    public interface IOrders
    {
        List<Orders> LoadOrder(DateTime date);
        Orders RemoveEditLoadOrder(DateTime date, string input);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interface
{
    public interface ICRUD
    {
        Orders Create(DateTime date, Orders order);
        bool Update(Orders newOrdersInfo);
        bool Delete(Orders order);
        List<Orders> LoadOrders(DateTime date);
        void SaveAllOrders(DateTime date, List<Orders> orders);
        Orders RemoveEditLoadOrder(DateTime date, string input);
    }
}

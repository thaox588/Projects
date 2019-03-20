
using FlooringMastery.Data;
using FlooringMastery.Data.Repository;
using FlooringMastery.Models;
using FlooringMastery.Models.Interface;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
       
        private ICRUD _order;

        public OrderManager(ICRUD orders)
        {
            _order = orders;
        }

        public OrderLookupResponse OrderLookup(DateTime date)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Orders = _order.LoadOrders(date);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"{date} is an invalid order!";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public RemoveOrderResponse DeleteOrder(Orders order)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();

            if (_order.Delete(order))
            {
                response.Success = true;
                response.order = order;
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid order!";
            }
            return response;
        }

        public EditOrderResponse EditOrder(Orders newOrdersInfo)
        {

            EditOrderResponse response = new EditOrderResponse();

            if (_order.Update(newOrdersInfo))
            {
                response.Success = true;
                response.order = newOrdersInfo;
            }
            else
            {
                response.Success = false;
                response.Message = "It's invalid";
            }
            return response;
        }

        public OrderAddResponse AddOrder(DateTime date, Orders order)
        {
            OrderAddResponse response = new OrderAddResponse();
            
            response.Order = _order.Create(date, order);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Invalid";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public List<Taxes> GetListTaxes()
        {
            List<Taxes> taxes = TaxesRepository.LoadTaxes();

            return taxes;
        }


        public Orders Calculate(Orders order)
        {
            Products selectedProduct = ProductsRepository.LoadProducts()
                .FirstOrDefault(p => p.ProductType == order.ProductType);

            Taxes selectedTax = TaxesRepository.LoadTaxes()
                .FirstOrDefault(t => t.StateAbbreviation == order.State);

            if(selectedProduct == null)
            {
                throw new Exception("Product not found!");
            }
            if(selectedTax == null)
            {
                throw new Exception("State not found!");
            }

            order.CostPerSquareFoot = selectedProduct.CostPerSquareFoot;
            order.LaborCostPerSquareFoot = selectedProduct.LaborCostPerSquareFoot;
            order.TaxRate = selectedTax.TaxRate;

            return order;
        }
    }   
}


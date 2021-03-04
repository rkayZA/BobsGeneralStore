using BobsGeneralStore.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsGeneralStore.AppLogic
{
    public class ShopService
    {
        private readonly int _taxRate;
        public ShopService()
        {
            _taxRate = 15; // TODO - Obtain Tax rate from Shop Setup File
        }
        
        public decimal CalculateTax(decimal subTotal, int taxRate)
        {

            return (subTotal * taxRate) / 100;
        }

        public decimal CalculateTotal(decimal subTotal, int taxRate)
        {
            var taxAmount = CalculateTax(subTotal, taxRate);
            return subTotal + taxAmount;
        }

        public decimal CalculateCartSubtotal(List<CartItem> itemsInCart)
        {
            var cartSubtotal = 0m;

            foreach (var item in itemsInCart)
            {
                cartSubtotal += (item.Item.UnitPrice * item.Quantity);
            }

            return cartSubtotal;
        }
    }
}

using BobsGeneralStore.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsGeneralStore.AppLogic.Data
{
    public class TestData
    {
        public int GenerateRandomQuantity()
        {
            int lowestQuantity = 1;
            int highestQuantity = 10;
            Random randomQuantity = new Random();

            return randomQuantity.Next(lowestQuantity, highestQuantity);
        }

        public List<Product> GetStockList()
        {
            var stockList = new List<Product>
            {
                new Product { ProductCode = 001, ProductDescription = "Bar of soap", UnitPrice = 12m},
                new Product { ProductCode = 002, ProductDescription = "Milk", UnitPrice = 14m },
                new Product { ProductCode = 003, ProductDescription = "Car magazine", UnitPrice = 7.00m},
                new Product { ProductCode = 004, ProductDescription = "Ice cream", UnitPrice = 20m},
                new Product { ProductCode = 005, ProductDescription = "can of soup", UnitPrice = 4m }
            };

            return stockList;
        }

        public List<CartItem> LoadShoppingCart()
        {
            var itemsInStock = GetStockList();
            var itemsInCart = new List<CartItem>();

            foreach (var item in itemsInStock)
            {
                itemsInCart.Add(new CartItem { Item = item, Quantity = GenerateRandomQuantity() });
            }

            return itemsInCart;
        }

        public Shop SetUpShop()
        {
            Shop newShop = new Shop
            {
                ShopName = "Bob's General Store",
                ShopLocation = "Durban",
                ShopPhoneNumber = "0314567890",
                ShopWebAddress = "www.bobsshop.com",
              
            };

            return newShop;
        }
    }
}

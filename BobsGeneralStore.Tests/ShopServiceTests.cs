using BobsGeneralStore.AppLogic;
using BobsGeneralStore.AppLogic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BobsGeneralStore.Tests
{
    public class ShopServiceTests : IDisposable
    {

        private readonly ShopService shopServices;
        private int _taxRate;
        private readonly List<Product> _stockList;
        private readonly List<CartItem>_itemsInCart;

        public ShopServiceTests()
        {
            shopServices = new ShopService();

            _stockList = new List<Product>
            {
                new Product { ProductCode = 001, ProductDescription = "Bar of soap", UnitPrice = 12m},
                new Product { ProductCode = 002, ProductDescription = "Milk", UnitPrice = 14m },
                new Product { ProductCode = 003, ProductDescription = "Car magazine", UnitPrice = 7.00m},
                new Product { ProductCode = 004, ProductDescription = "Ice cream", UnitPrice = 20m},
                new Product { ProductCode = 005, ProductDescription = "can of soup", UnitPrice = 4m }
            };

            _itemsInCart = new List<CartItem>
            {
                new CartItem { Item = _stockList[0], Quantity = 2},
                new CartItem { Item = _stockList[1], Quantity = 1},
                new CartItem { Item = _stockList[2], Quantity = 2},
                new CartItem { Item = _stockList[3], Quantity = 1},
                new CartItem { Item = _stockList[4], Quantity = 4},
            };
        }

        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(100, 10, 10)]
        [InlineData(150, 15, 22.5)]
        [InlineData(200, 20, 40)]
        public void CalculateTaxAmountOnSubTotal(decimal subTotal, int taxRate, decimal expectedTaxAmount)
        {
            var calculatedTaxAmount = shopServices.CalculateTax(subTotal, taxRate);

            Assert.Equal(expectedTaxAmount, calculatedTaxAmount);
        }

        [Fact]
        public void CaclulateTotalIncludingTax_15()
        {
            _taxRate = 15;
            var totalWithTax = shopServices.CalculateTotal(100, _taxRate);

            Assert.Equal(115, totalWithTax);
        }

        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(100, 10, 110)]
        [InlineData(150, 15, 172.5)]
        [InlineData(200, 20, 240)]
        public void CaclulateTotalIncludingTax(decimal subTotal, int taxRate, decimal expectedTotalAmount)
        {
            var totalWithTax = shopServices.CalculateTotal(subTotal, taxRate);

            Assert.Equal(expectedTotalAmount, totalWithTax);
        }

        [Fact]
        public void CaclulateSubtotalForCartItems()
        {
            var expectedSubtotalAmount = 0m;

            foreach (var item in _itemsInCart)
            {
                expectedSubtotalAmount += (item.Item.UnitPrice * item.Quantity);
            }

            var actualSubTotalAmount = 0m;
            actualSubTotalAmount = shopServices.CalculateCartSubtotal(_itemsInCart);

            Assert.Equal(expectedSubtotalAmount, actualSubTotalAmount);
        }

        public void Dispose()
        {
            // nothing here yet
        }
    }
}

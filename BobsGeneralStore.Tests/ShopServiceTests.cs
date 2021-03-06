using BobsGeneralStore.AppLogic;
using BobsGeneralStore.AppLogic.Data;
using BobsGeneralStore.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;


namespace BobsGeneralStore.Tests
{
    public class ShopServiceTests : IDisposable
    {

        private readonly ShopService shopServices;
        private readonly TestData testData = new TestData();
        private int _taxRate;
        private readonly List<Product> _stockList;
        private readonly List<CartItem> _itemsInCart;
        private readonly Shop _bobsShop;

        public ShopServiceTests()
        {
            shopServices = new ShopService();
            _stockList = testData.GetStockList();
            _itemsInCart = testData.LoadShoppingCart();
            _bobsShop = testData.SetUpShop();
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

        [Fact]
        public void ShopNameCannotBeBlankOrNull()
        {
            Assert.True(!string.IsNullOrWhiteSpace(_bobsShop.ShopName));
        }

        [Fact]
        public void ShopHasValidTaxRate()
        {
            Assert.True(_bobsShop.ShopTaxRate >= 0);
        }

        [Fact]
        public void ShopSetupFileExists()
        {
            var setupFilename = "ShopSetup.csv";

            Assert.True(File.Exists(setupFilename));

        }



        public void Dispose()
        {
            // nothing here yet
        }
    }
}

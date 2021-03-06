using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsGeneralStore.AppLogic.Models
{
    public class Shop
    {
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }

        public string ShopPhoneNumber { get; set; }

        public string ShopWebAddress { get; set; }
        public int ShopTaxRate { get; set; } = 0;
    }
}

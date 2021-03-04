using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsGeneralStore.AppLogic.Models
{
    public class CartItem
    {
        public Product Item { get; set; } = new Product();
        public int Quantity { get; set; }
    }
}

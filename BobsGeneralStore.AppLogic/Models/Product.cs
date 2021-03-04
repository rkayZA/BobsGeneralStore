using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsGeneralStore.AppLogic.Models
{
    public class Product
    {
        public int ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Entities
{
    public class SaleDetail : EntityBase
    {
        public string SaleId { get; set; }

        public Sale Sale { get; set; }

        public int ItemNumber { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }
    }
}

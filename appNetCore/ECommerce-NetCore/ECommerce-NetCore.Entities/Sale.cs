using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Entities
{
    public class Sale : EntityBase
    {
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime SaleDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string PaymentMethod { get; set; }

        public decimal TotalSale { get; set; }
    }
}

using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StripeVM
    {
        public Balance Balance { get; set; }
        public List<BalanceTransaction> Transactions { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Charge> Charges { get; set; }
        public List<Dispute> Disputes { get; set; }
        public List<Refund> Refunds { get; set; }
        public List<Product> Products { get; set; }
    }
}

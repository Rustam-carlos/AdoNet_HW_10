using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    public class Order
    {
        public int ID { get; set; }
        public Client client { get; set; }
        public Seller seller { get; set; }
        public DateTime Date { get; set; }
        public Product product { get; set; }
        public int ProductCount { get; set; }
        public int Sum { get; set; }
    }
}

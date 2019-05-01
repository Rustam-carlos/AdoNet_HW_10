using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    public class Basket
    {
        public int ID { get; set; }
        public Client client { get; set; }
        public List<Order> orders { get; set; }
        public int summ { get; set; }
    }
}

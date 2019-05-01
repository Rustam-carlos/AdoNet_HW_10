using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    public class Seller
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public List<Order> orders { get; set; }
    }
}

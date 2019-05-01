using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_10
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirmName { get; set; }
        public Category category { get; set; }
        public int Price { get; set; }
    }
}

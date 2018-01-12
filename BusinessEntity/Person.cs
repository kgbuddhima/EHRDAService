using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Sex { get; set; }
        public Address Address { get; set; }

    }
}

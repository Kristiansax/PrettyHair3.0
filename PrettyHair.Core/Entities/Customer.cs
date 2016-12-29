using PrettyHair.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Entities
{
    public class Customer : ICustomer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Customer(string f, string l)
        {
            Firstname = f;
            Lastname = l;
        }
    }
}

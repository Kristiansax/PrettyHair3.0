using PrettyHair.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Entities
{
    public class Ware : IWare
    {
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Designation { get; set; }

        public Ware(int P, int A, string Desc)
        {
            Price = P;
            Amount = A;
            Designation = Desc;
        }

    }
}


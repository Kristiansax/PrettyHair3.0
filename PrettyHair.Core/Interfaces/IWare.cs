using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Interfaces
{
    public interface IWare
    {
        double Price { get; set; }
        int Amount { get; set; }
        string Designation { get; set; }
    }
}

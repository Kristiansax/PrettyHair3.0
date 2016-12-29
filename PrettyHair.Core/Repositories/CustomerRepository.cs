using PrettyHair.Core.Entities;
using PrettyHair.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core
{
    public class CustomerRepository
    {
        public Dictionary<int, ICustomer> CustomerList = new Dictionary<int, ICustomer>();
        int Id = 1;
        public CustomerRepository()
        {

        }
        public Dictionary<int, ICustomer> GetCustomer()
        {
            return CustomerList;
        }
        public void AddCustomer(Customer cus)
        {
            CustomerList.Add(Id++, cus);
        }
        public void DeleteCustomerByID(int ID)
        {
            CustomerList.Remove(ID);
        }
        public Dictionary<int, ICustomer> GetAllCustomers()
        {
            return CustomerList;
        }
        public Customer GetCustomerByID(int ID)
        {
            return null;
        }
        public void Clear()
        {

        }
    }
}

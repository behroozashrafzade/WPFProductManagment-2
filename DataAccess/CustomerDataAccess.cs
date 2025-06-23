using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public CustomerDataAccess()
        {
            ReadCustomer();
        }

        private void ReadCustomer()
        {
            Customer cst1 = new Customer()
            {
                Id = 1,
                FirstName = "mamad",
                LastName = "zmani",
                PhoneNumber = 0913131441,
                Address = "esf",

            };
            Customer cst2 = new Customer()
            {
                Id = 2,
                FirstName = "saiid",
                LastName = "salimian",
                PhoneNumber = 09136454383,
                Address = "esf",

            };
            Customers.Add(cst1);
            Customers.Add(cst2);
        }

        public void AddCustomer(Customer cst)
        {
            Customers.Add(cst);
        }

        public void RemoveCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);

            Customers.Remove(temp);
        }

        public void EditCustomer(Customer cst)
        {
            Customer temp = Customers.First(x => x.Id == cst.Id);

            int index = Customers.IndexOf(temp);

            Customers[index] = cst;
        }

        public int getNextId()
        {
            int index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            return index;
        }

    }
}

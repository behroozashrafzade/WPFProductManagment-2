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
        private string path = @"./DemoDBCustomer.csv";
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public CustomerDataAccess()
        {
            ReadCustomer();
        }

        private void ReadCustomer()
        {
            using (var reader = new StreamReader(path))
            {
                Customers.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] values = line.Split(';');
                   
                    Customer emp = new Customer()
                    {
                        Id = Convert.ToInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        PhoneNumber = Convert.ToUInt64(values[3]),
                        Address = values[4],
                      
                    };
                    Customers.Add(emp);
                }
            }
        }
        private void SaveCustomers()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Customer emp in Customers)
                {

                    string Id = emp.Id.ToString();
                    string FirstName = emp.FirstName;
                    string LastName = emp.LastName;
                    string PhoneNumber = emp.PhoneNumber.ToString();
                    string Address = emp.Address;
                    

                    string line = string.Format("{0};{1};{2};{3};{4}"
                        , Id, FirstName, LastName, PhoneNumber, Address);
                    writer.WriteLine(line);
                }
            }
        }

        public void AddCustomer(Customer cst)
        {
            Customers.Add(cst);
            SaveCustomers();
        }

        public void RemoveCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);

            Customers.Remove(temp);
            SaveCustomers();
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

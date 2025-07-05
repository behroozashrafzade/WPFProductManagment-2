using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class ProductDataAccess
    {
        private string path = @"./DemoDBProduct.csv";
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductDataAccess()
        {
            ReadProducts();
        }

        private void ReadProducts()
        {
            using (var reader = new StreamReader(path))
            {
                Products.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] values = line.Split(';');
                   
                    Product emp = new Product()
                    {
                        Id = Convert.ToInt32(values[0]),
                        Name = values[1],
                        Author = values[2],
                        Price = Convert.ToUInt64(values[3]),
                        AvailableCount = Convert.ToInt32(values[4])

                    };
                    Products.Add(emp);
                }
            }
        }

        private void SaveProducts()
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (Product emp in Products)
                {

                    string Id = emp.Id.ToString();
                    string Name = emp.Name;
                    string Author = emp.Author;
                    string Price = emp.Price.ToString();
                    string AvailableCountl = emp.AvailableCount.ToString();
                    

                    string line = string.Format("{0};{1};{2};{3};{4}"
                        , Id, Name, Author, Price, AvailableCountl);
                    writer.WriteLine(line);
                }
            }
        }
    


public void AddProduct(Product product)
        {
            Products.Add(product);
            SaveProducts();
        }

        public void RemoveProduct(int id)
        {
            Product temp = Products.First(x => x.Id == id);

            Products.Remove(temp);
            SaveProducts();
        }

        public void EditProduct(Product product)
        {
            Product temp = Products.First(x => x.Id == product.Id);

            int index = Products.IndexOf(temp);

            Products[index] = product;
        }

        public int getNextId()
        {
            int index = Products.Any() ? Products.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
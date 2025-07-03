using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFProductManagment
{
    /// <summary>
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private ProductDataAccess productsDataAccess;
        private Product editingProduct;
        private bool isEdit = false;

        public AddEditProduct(ProductDataAccess proDataAccess)
        {
            InitializeComponent();
            productsDataAccess = proDataAccess;
        }
        public AddEditProduct(ProductDataAccess proDataAccess, Product emp)
        {
            InitializeComponent();
            productsDataAccess = proDataAccess;
            editingProduct = emp;
            isEdit = true;
            tbName.Text = editingProduct.Name;
            tbAuthor.Text = editingProduct.Author;
            tbAvailable.Text = editingProduct.AvailableCount.ToString();
            tbPrice.Text = editingProduct.Price.ToString();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckProductValidity();
            if (isValid)
            {

                if (isEdit)
                {
                    Product emp = new Product()
                    {
                        Id = editingProduct.Id,
                        Author = tbAuthor.Text,
                        Name = tbName.Text,
                        AvailableCount = int.Parse(tbAvailable.Text),
                        Price = decimal.Parse(tbPrice.Text)

                    };
                    productsDataAccess.EditProduct(emp);
                }
                else
                {
                    Product emp = new Product()
                    {
                        Id = productsDataAccess.getNextId(),
                        Name = tbName.Text,
                        Author = tbAuthor.Text,
                        AvailableCount = int.Parse(tbAvailable.Text),
                        Price = Convert.ToDecimal(tbPrice.Text),

                    };
                    productsDataAccess.AddProduct(emp);
                }

                this.Close();
            }

        }
        private bool CheckProductValidity()
        {


            bool isValid = true;

            string Name = tbName.Text.Trim().ToLower();
            string Author = tbAuthor.Text.Trim().ToLower();
            string Available = tbAvailable.Text.Trim().ToLower();
            string Price = tbPrice.Text.Trim().ToLower();
            

            if (string.IsNullOrEmpty(Name))
            {
                isValid = false;
                lblError.Content = " name is invalid !";
            }
            else if (string.IsNullOrEmpty(Author))
            {
                isValid = false;
                lblError.Content = "Author is invalid !";
            }

            else if (!UInt64.TryParse(Price, out ulong p))
            {
                isValid = false;
                lblError.Content = "Price is invalid !";
            }
            else if (!UInt64.TryParse(Available, out ulong q)|| string.IsNullOrEmpty(Available))
            {
                isValid = false;
                lblError.Content = "Available is invalid !";
            }
            
            else
            {
                lblError.Content = "";

            }

            return isValid;
        }

        private void TbPrice_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string Pr = tbPrice.Text.Trim().ToLower();
            if (!UInt64.TryParse(Pr, out ulong p))
            {

                lblError.Content = "Phone Number is invalid !";
            }
            else
            {
                lblError.Content = "";
            }
        }
    }
}

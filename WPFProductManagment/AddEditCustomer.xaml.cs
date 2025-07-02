using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerDataAccess CustomerrDataAccess;
        private Customer editingCustomer;
        private bool isEdit = false;

        public AddEditCustomer(CustomerDataAccess prdDataAccess)
        {
            InitializeComponent();
            CustomerrDataAccess = prdDataAccess;
        }

        public AddEditCustomer(CustomerDataAccess prdDataAccess, Customer emp)
        {
            InitializeComponent();
            CustomerrDataAccess = prdDataAccess;
            editingCustomer = emp;
            isEdit = true;
            tbFirstName.Text = editingCustomer.FirstName;
            tbLastName.Text = editingCustomer.LastName;
            tbPhoneNumber.Text = editingCustomer.PhoneNumber.ToString();
            tbAddress.Text= editingCustomer.Address;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                Customer emp = new Customer()
                {
                    Id = editingCustomer.Id,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text)
                    
                };
                CustomerrDataAccess.EditCustomer(emp);
            }
            else
            {
                Customer emp = new Customer()
                {
                    Id = CustomerrDataAccess.getNextId(),
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                    
                };
                CustomerrDataAccess.AddCustomer(emp);
            }

            this.Close();
        }

        private void TbPhoneNumber_OnTextChanged(object sender, TextChangedEventArgs e)
        {

           
        }
    }
}

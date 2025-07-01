using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;

namespace WPFProductManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> customers= new ObservableCollection<Customer>();
        ObservableCollection<Product> Products = new ObservableCollection<Product>();

        public Employee CurrentEmployee { get; set; }= new Employee();

        public Customer CurrentCustomer { get; set; }=new Customer();

        public Product CurrentProduct { get; set; } = new Product();

        public MainWindow()
        {
            InitializeComponent();

            fillData();

            EmployeesGrid.ItemsSource = employees;
            CustomersGrid.ItemsSource=customers;
            ProductsGrid.ItemsSource=Products;
        }

        private void fillData()
        {
            employees = employeeDataAccess.Employees;
           customers=customerDataAccess.Customers;
           Products=productDataAccess.Products;
        }

        private void BtnHome_OnClick(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility= Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility= Visibility.Collapsed;
        }

        private void BtnEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnCustomers_OnClick(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnProducts_OnClick(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }

        private void EmployeesGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EmployeesGrid.SelectedIndex>=0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                Employeelabel.Content = CurrentEmployee.GetBasicInfo();
            }
        }

        private void BtnAddEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess);
            addWindow.ShowDialog();
        }

        private void BtnDeleteEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                employeeDataAccess.RemoveEmployee(CurrentEmployee.Id);
                Employeelabel.Content = "---";

            }

        }

        private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                AddEditEmployee addWindow = new AddEditEmployee(employeeDataAccess,CurrentEmployee);
                addWindow.ShowDialog();

            }
        }

        private void CustomersGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                Customerlabel.Content = CurrentCustomer.GetBasicInfo();

            }
        }

        private void BtnAddCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            AddEditCustomer addWindow = new AddEditCustomer(customerDataAccess);
            addWindow.ShowDialog();
        }

        private void BtnDeleteCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                customerDataAccess.RemoveCustomer(CurrentCustomer.Id);
                Customerlabel.Content = "---";

            }
        }

        private void BtnEditCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                AddEditCustomer addWindow = new AddEditCustomer(customerDataAccess, CurrentCustomer);
                addWindow.ShowDialog();

            }
        }

        private void ProductsGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                Productslabel.Content = CurrentProduct.GetBasicInfo();
            }
        }

        private void BtnAddProducts_OnClick(object sender, RoutedEventArgs e)
        {
            AddEditProduct addWindow = new AddEditProduct(productDataAccess);
            addWindow.ShowDialog();
        }

        private void BtnDeleteProducts_OnClick(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                productDataAccess.RemoveProduct(CurrentProduct.Id);
                Productslabel.Content = "---";

            }
        }

        private void BtnEditProducts_OnClick(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                AddEditProduct addWindow = new AddEditProduct(productDataAccess, CurrentProduct);
                addWindow.ShowDialog();

            }
        }
    }
}
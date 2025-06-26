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
using DataAccess;
using DataAccess.Models;

namespace WPFProductManagment
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeDataAccess employeeDataAccess;
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee()
            {
                Id = employeeDataAccess.getNextId(),
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Address = tbAddress.Text,
                PhoneNumber =Convert.ToUInt64(tbPhoneNumber.Text),
                BaseSalary = Convert.ToDecimal(tbSalary.Text),
                Department =(Department) comboDepartment.SelectedIndex
            };
            employeeDataAccess.AddEmployee(emp);
        }
    }
}

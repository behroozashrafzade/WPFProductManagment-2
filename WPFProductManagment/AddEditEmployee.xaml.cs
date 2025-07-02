using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private Employee editingEmployee;
        private bool isEdit =false;
        public AddEditEmployee(EmployeeDataAccess empDataAccess)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
        }
        public AddEditEmployee(EmployeeDataAccess empDataAccess,Employee emp)
        {
            InitializeComponent();
            employeeDataAccess = empDataAccess;
            editingEmployee = emp;
            isEdit=true;
            tbFirstName.Text = editingEmployee.FirstName;
            tbLastName.Text = editingEmployee.LastName;
            tbPhoneNumber.Text = editingEmployee.PhoneNumber.ToString();
            tbSalary.Text = editingEmployee.BaseSalary.ToString();
            comboDepartment.SelectedIndex=(int)editingEmployee.Department;

        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            isValid = CheckEmployeeValidity();
            if (isValid)
            {

                if (isEdit)
                {
                    Employee emp = new Employee()
                    {
                        Id = editingEmployee.Id,
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        Address = tbAddress.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex
                    };
                    employeeDataAccess.EditEmployee(emp);
                }
                else
                {
                    Employee emp = new Employee()
                    {
                        Id = employeeDataAccess.getNextId(),
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        Address = tbAddress.Text,
                        PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                        BaseSalary = Convert.ToDecimal(tbSalary.Text),
                        Department = (Department)comboDepartment.SelectedIndex
                    };
                    employeeDataAccess.AddEmployee(emp);
                }

                this.Close();
            }
        }

        private bool CheckEmployeeValidity()
        {
           

            bool isValid = true;

            string FirstName = tbFirstName.Text.Trim().ToLower();
            string LastName = tbLastName.Text.Trim().ToLower();
            string Address = tbAddress.Text.Trim().ToLower();
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
            int Department = comboDepartment.SelectedIndex;
            string BaseSalary = tbSalary.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(FirstName))
            {
                isValid=false;
                lblError.Content = "First name is invalid !" ;
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                isValid = false;
                lblError.Content = "Last name is invalid !" ;
            }

            else if (!UInt64.TryParse(PhoneNumber,out ulong p))
            {
                isValid = false;
                lblError.Content = "Phone Number is invalid !"  ;
            }
            else if (Address.Contains("iran")||string.IsNullOrEmpty(Address))
            {
                isValid = false;
                lblError.Content = "Address is invalid !" ;
            }
            else if (Department<0)
            {
                isValid = false;
                lblError.Content = "Please Select a Department !" ;
            }
            else if (!decimal.TryParse(BaseSalary, out decimal b) || b > 4000)
            {
                isValid = false;
                lblError.Content = "salary is invalid !";
            }
            else
            {
                lblError.Content = "";

            }

            return isValid;
        }


        private void TbPhoneNumber_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string PhoneNumber = tbPhoneNumber.Text.Trim().ToLower();
             if (!UInt64.TryParse(PhoneNumber, out ulong p))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class EmployeeDataAccess
    {

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public EmployeeDataAccess()
        {
            ReadEmployee();
        }

        private void ReadEmployee()
        {
            Employee emp1 = new Employee()
            {
                Id = 1,
                FirstName = "bahrouz",
                LastName = "ashrafzade",
                PhoneNumber = 0913131441,
                Address = "esf",
                Department = Department.Production,
                BaseSalary = 1500
            };
            Employee emp2 = new Employee()
            {
                Id = 2,
                FirstName = "davoood",
                LastName = "ashrafzade",
                PhoneNumber = 09136454383,
                Address = "esf",
                Department = Department.Production,
                BaseSalary = 2500
            };
            Employees.Add(emp1);
            Employees.Add(emp2);
        }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
        }

        public void RemoveEmployee(int id)
        {
            Employee temp = Employees.First(x => x.Id == id);

            Employees.Remove(temp);
        }

        public void EditEmployee(Employee emp)
        {
            Employee temp = Employees.First(x => x.Id == emp.Id);

            int index = Employees.IndexOf(temp);

            Employees[index] = emp;
        }

        public int getNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        }




    }
}

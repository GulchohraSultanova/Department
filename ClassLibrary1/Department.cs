using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Department
    {
        public int No;
        public int EmployeeLimit;
        public Employee[] Employees = new Employee[0];

        public Department(int no, int limit)
        {
            No = no;
            EmployeeLimit = limit;
        }
        public void AddEmployee(Employee employee)
        {
            if (EmployeeLimit >= Employees.Length)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
                Console.WriteLine("Employee added!");

            }
            else
            {
                Console.WriteLine("Employee not added");
            }
        }
        public Employee[] GetAllEmployyes()
        {
            return Employees;
        }
        public Employee[] GetAllEmployeesBySalary(int minSalary, int maxSalary)
        {
            bool flag = false;

            Employee[] salaryEmployee = new Employee[0];
            foreach (Employee employee in Employees)
            {
                if (employee.Salary >= minSalary && employee.Salary <= maxSalary)
                {
                    flag = true;
                    Array.Resize(ref salaryEmployee, salaryEmployee.Length + 1);
                    salaryEmployee[salaryEmployee.Length - 1] = employee;
                }

            }
            if (flag)
            {
                Console.WriteLine("Employees of department in this salary range:");

            }
            else
            {
                Console.WriteLine("No employee in this salary range.");
            }
            return salaryEmployee;

        }
        public Employee[] GetAllEmployeesByPosition(string position)
        {
            bool flag = false;

            Employee[] positionEmployee = new Employee[0];
            foreach (Employee employee in Employees)
            {
                if (employee.Position == position)
                {
                    flag = true;
                    Array.Resize(ref positionEmployee, positionEmployee.Length + 1);
                    positionEmployee[positionEmployee.Length - 1] = employee;
                }

            }
            if (flag)
            {
                Console.WriteLine("Employees of department in this position:");

            }
            else
            {
                Console.WriteLine("No employee in this position.");
            }
            return positionEmployee;

        }
        public void ShowEmployeeInfo()
        {

            if (Employees.Length > 0)
            {
                Console.WriteLine("Employees:");
                foreach (Employee employee in Employees)
                {

                    employee.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Employees is empty!");
            }





        }
    }
}

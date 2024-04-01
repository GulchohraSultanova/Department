using Core;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace DepartmentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Department department = CreateDepartment();
            bool flag = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-----------Welcome my EmployeeApp-----------");
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Added Employee in Department!");
                Console.WriteLine("2.Show Employees in Department!");
                Console.WriteLine("3.Show Employees by Salary Range in Department!");
                Console.WriteLine("4.Show Employees Search Position  in Department!");
                Console.WriteLine("0.Exit App....");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();
                string name, surname, departmentName,position;
                int id,departmentNo,minSalary,maxSalary;
                byte age;
                double salary;

                switch (choice)
                {
                    case "1":

                       
                        Console.Write("Enter employee name: ");

                        while (true)
                        {
                            name = Console.ReadLine();

                            if (!string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                            {
                                break;
                            }
                        }
                        Console.Write("Enter employee surname: ");

                        while (true)
                        {
                            surname = Console.ReadLine();

                            if (!string.IsNullOrEmpty(surname) && Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
                            {
                                break;
                            }
                        }
                        Console.Write("Enter employee age: ");

                        while (!byte.TryParse(Console.ReadLine(), out age) || age <= 0)
                        {
                            Console.WriteLine("Please enter correct age!");
                            Console.Write("Enter employee age: ");
                        }

                        Console.Write("Enter employee position: ");
                        while (true)
                        {
                            position = Console.ReadLine();


                            if (!string.IsNullOrEmpty(position))
                            {
                                break;
                            }
                        }

                       
                        Console.Write("Enter employee salary: ");
                        while (!double.TryParse(Console.ReadLine(), out salary) || salary <= 0)
                        {
                            Console.WriteLine("Please enter corret salary!");
                            Console.Write("Enter employee salary: ");
                        }

                     
                        Employee newEmployee = new Employee(name, surname, age, position,salary);
                        department.AddEmployee(newEmployee);
                        newEmployee.DepartmentNo = department.No;

                        break;
                      
                    case "2":
                       department.ShowEmployeeInfo();

                        break;
                    case "3":
                        Console.Write("Enter minimum salary: ");
                        while (!int.TryParse(Console.ReadLine(), out minSalary) || minSalary <= 0)
                        {
                            Console.WriteLine("Please enter correct minumum salary!");
                            Console.Write("Enter minimum salary: ");
                        }

                        Console.Write("Enter maximum salary: ");
                        while (!int.TryParse(Console.ReadLine(), out maxSalary) || maxSalary <= 0 || maxSalary < minSalary)
                        {
                            Console.WriteLine("Please enter correct maximum salary!");
                            Console.Write("Enter maximum salary: ");
                        }
                        Employee[] employyeSalary = department.GetAllEmployeesBySalary(minSalary, maxSalary);

                        foreach (Employee emp in employyeSalary)
                        {
                            emp.ShowInfo();
                        }
                        break;
                      
                    case "4":
                        Console.WriteLine("Enter position: ");
                        string pos = Console.ReadLine();
                        foreach (var item in department.GetAllEmployeesByPosition(pos))
                        {
                            item.ShowInfo();
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program...");
                        flag = true;
                        break;

                        break;
                    default:
                        Console.WriteLine("This is not correct! Please, enter correct choice!");
                        break;
                }

            } while (!flag);

            static Department CreateDepartment()
            {
                int no;
                int employeeLimit;
                Console.Write("Enter department no: ");

                while (!int.TryParse(Console.ReadLine(), out no) || no <= 0)
                {
                    Console.WriteLine("Please enter correct department no!");
                    Console.Write("Enter department no: ");
                }
                do
                {
                    Console.WriteLine("Enter the employee limit: ");

                } while (!int.TryParse(Console.ReadLine(), out employeeLimit) || employeeLimit < 0 || employeeLimit > 20);
                return new Department(no, employeeLimit);
            }



        }
    }
}
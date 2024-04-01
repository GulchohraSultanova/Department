using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Employee
    {
        private static int _id =0;
        public int Id;
        public string Name;
        public string SurName;
        public byte Age;
        public int DepartmentNo;
        public string Position;
        private double _salary;
       

        public double Salary
        {
            get { return _salary; }
            set {
                if (value > 10)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Maas duzgun deyil");
                }
            }
        }
        public Employee(string name, string surname, byte age, string position, double salary)
        {
            _id++;
            Id = _id;
            Name = name;
            SurName = surname;
            Age = age;
           
            Position = position;
            Salary = salary;
        }

        
        public void ShowInfo() {
            Console.WriteLine($"iD: {Id}, Name: {Name}, Surname: {SurName}, Age: {Age}, Department No: {DepartmentNo}  Position: {Position}   Salary: {Salary}");
        }
    }
}

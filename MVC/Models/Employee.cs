using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public double BaseSalary { get; set; }

        public EmployeeType Type { get; set; }
        public Employee Boss { get; set; }
        public static List<Employee> Stuff { get; } = new List<Employee>();
        public IEnumerable<Employee> Employees(DateTime date) => Stuff.Where(e => e.Boss == this && e.HireDate <= date); 
        public string OrderID
        {
            get
            {
                string orderID = null;
                var emp = this;

                while (emp != null)
                {
                    orderID = $"{emp.GetHashCode()}>{orderID}";
                    emp = emp.Boss;
                }

                return orderID;
            }
        }
        public int Ident
        {
            get
            {
                int ident = 0;
                var emp = this.Boss;

                while (emp != null)
                {
                    emp = emp.Boss;

                    ident++;
                }

                return ident;
            }
        }
        public string IdentName
        {
            get
            {
                var sb = new System.Text.StringBuilder();

                for (int i = 0; i < Ident; i++)
                    sb.Append("&emsp;");

                sb.Append(Name);

                return sb.ToString();
            }
        }
        protected virtual string CheckData(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name must be filled!";
            else if (hireDate == DateTime.MinValue)
                return "Hire date must be filled!";
            else if (type == null)
                return "Employee type must be filled!";
            else if (!type.CanBeBoss && boss != null)
                return "This kind of employee can't be boss!";
            else if (baseSalary <= 0)
                return "Salary must be positive!";
            else
                return null;
        }
        public Employee(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary = 1000)
        {
            var error = CheckData(name, hireDate, type, boss, baseSalary);

            if (error != null)
                new Exception(error);

            Name = name;
            HireDate = hireDate;
            BaseSalary = baseSalary;
            Type = type;
            Boss = boss;

            Stuff.Add(this);
        }
        public virtual (double Salary, double Total) CalcSalaryForDate(DateTime date)
        {            
            int years = date.Year - HireDate.Year;

            if (date.Month < HireDate.Month || (date.Month == HireDate.Month && date.Day < HireDate.Day))
                years--;

            if (years < 0)
                return (Salary: 0, Total: 0);

            double total = GetEmployeesSalaries(date);

            double salary = Math.Min(BaseSalary * (1 + years * Type.Rate), BaseSalary * (1 + Type.Limit));

            if (total == 0)
                total = salary;
            else
            {
                salary += total * Type.EmployeeRate;
                total += salary;
            }

            return (Salary: salary, Total: total);
        }
        protected virtual double GetEmployeesSalaries(DateTime date) => 0;
        public virtual double GetSalaryForDate(DateTime date) => CalcSalaryForDate(date).Salary;
    }
}

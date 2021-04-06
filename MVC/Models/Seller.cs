using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Seller : Employee
    {
        public Seller(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary = 1000) :
            base(name, hireDate, type, boss, baseSalary)
        { }
        protected override string CheckData(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary)
        {
            string result = base.CheckData(name, hireDate, type, boss, baseSalary);

            if (result == null && !type.CanBeBoss)
                result = "Seller can have the employees!";

            return result;
        }
        protected override double GetEmployeesSalaries(DateTime date)
        {
            double total = 0;
            double localTotal = 0;

            foreach (var emp in Employees(date))
            {
                (_, localTotal) = emp.CalcSalaryForDate(date);

                total += localTotal;
            }

            return total;
        }
    }
}

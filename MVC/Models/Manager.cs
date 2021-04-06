using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Manager : Employee
    {
        public Manager(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary = 1000) :
            base(name, hireDate, type, boss, baseSalary)
        { }
        protected override string CheckData(string name, DateTime hireDate, EmployeeType type, Employee boss, double baseSalary)   
        {
            string result = base.CheckData(name, hireDate, type, boss, baseSalary);

            if (result == null && !type.CanBeBoss)
                result = "Manager can have the employees!";

            return result;
        }
        protected override double GetEmployeesSalaries(DateTime date)
        {
            double total = 0;
            double localSalary = 0;

            foreach (var emp in Employees(date))
            {
                (localSalary, _) = emp.CalcSalaryForDate(date);

                total += localSalary;
            }

            return total;
        }
    }

}

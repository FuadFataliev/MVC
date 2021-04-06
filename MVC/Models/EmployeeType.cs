using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class EmployeeType
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public double Limit { get; set; }
        public double EmployeeRate { get; set; }
        public bool CanBeBoss { get; set; }

        public EmployeeType(string name, double rate, double limit, double employeeRate, bool canBeBoss)
        {
            var error = CheckData(name, rate, limit, employeeRate);

            if (error != null)
                new Exception(error);

            Name = name;
            Rate = rate;
            Limit = limit;
            EmployeeRate = employeeRate;
            CanBeBoss = canBeBoss;
        }
        protected virtual string CheckData(string name, double rate, double limit, double employeeRate)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name must be filled!";
            else if (rate <= 0)
                return "Rate must be positive number!";
            else if (limit <= 0)
                return "Salary limit must be positive number!";
            else if (employeeRate <= 0)
                return "Rate per employee must be positive number!";
            else
                return null;
        }
    }
}

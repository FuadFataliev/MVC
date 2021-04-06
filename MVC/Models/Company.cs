using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    class Company : Services.ICompany
    {
        public virtual void FillStuff()
        {
            EmployeeType Employee = new EmployeeType("Employee", 0.03, 0.3, 0, false);
            EmployeeType Manager = new EmployeeType("Manager", 0.05, 0.5, 0.005, true);
            EmployeeType Seller = new EmployeeType("Seller", 0.01, 0.35, 0.003, true);

            var topManager = new Manager("Top Manager", new DateTime(2010, 1, 1), Manager, null, 10000);

            var subManager1 = new Manager("Sub Manager 1", new DateTime(2010, 3, 1), Manager, topManager, 5000);
            var subManager2 = new Manager("Sub Manager 2", new DateTime(2010, 3, 1), Manager, topManager, 5000);

            var seller11 = new Seller("Seller 11", new DateTime(2010, 6, 1), Seller, subManager1, 3000);
            var seller12 = new Seller("Seller 12", new DateTime(2010, 6, 1), Seller, subManager1, 3000);
            var seller13 = new Seller("Seller 13", new DateTime(2010, 6, 1), Seller, subManager1, 3000);

            var seller21 = new Seller("Seller 21", new DateTime(2010, 9, 1), Seller, subManager2, 3000);
            var seller22 = new Seller("Seller 22", new DateTime(2010, 9, 1), Seller, subManager2, 3000);
            var seller23 = new Seller("Seller 23", new DateTime(2010, 9, 1), Seller, subManager2, 3000);

            var seller231 = new Seller("Seller 231", new DateTime(2010, 9, 1), Seller, seller23, 3000);
            var subManager232 = new Seller("Manager 232", new DateTime(2010, 9, 1), Manager, seller23, 5000);

            var employee111 = new Employee("Employee 111", new DateTime(2010, 12, 1), Employee, seller11);
            var employee112 = new Employee("Employee 112", new DateTime(2010, 12, 1), Employee, seller11);

            var employee131 = new Employee("Employee 131", new DateTime(2010, 12, 1), Employee, seller13);
            var employee132 = new Employee("Employee 132", new DateTime(2010, 12, 1), Employee, seller13);

            var employee221 = new Employee("Employee 221", new DateTime(2010, 12, 1), Employee, seller22);
            var employee231 = new Employee("Employee 231", new DateTime(2010, 12, 1), Employee, seller23);

            var employee2311 = new Employee("Employee 2311", new DateTime(2010, 12, 1), Employee, seller231);
            var employee2312 = new Employee("Employee 2312", new DateTime(2010, 12, 1), Employee, seller231);

            var employee2321 = new Employee("Employee 2321", new DateTime(2010, 12, 1), Employee, subManager232);
            var employee2322 = new Employee("Employee 2322", new DateTime(2010, 12, 1), Employee, subManager232);
        }
        public virtual IEnumerable<Employee> Stuff { get => Employee.Stuff; }
    }
}

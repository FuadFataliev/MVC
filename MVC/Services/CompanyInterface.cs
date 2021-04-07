using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public interface ICompany
    {
        void FillStaff();
        IEnumerable<Models.Employee> Staff { get; }
    }
}

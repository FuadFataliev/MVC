using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public interface ICompany
    {
        void FillStuff();
        IEnumerable<Models.Employee> Stuff { get; }
    }
}

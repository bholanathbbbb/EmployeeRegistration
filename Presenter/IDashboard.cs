using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Presenter
{
    public interface IDashboard
    {
        List<Employee> EmployeeInfo { set; }
    }
}

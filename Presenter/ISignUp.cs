using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Presenter
{
    public interface ISignUp
    {
        Employee EmployeeInfo { get; set; }
        List<ReferenceKey> FillRoleDropdown { set; }
        List<ReferenceKey> FillServiceLineDropdown { set; }
        List<ReferenceKey> FillDesignationDropdown { set; }

    }
}

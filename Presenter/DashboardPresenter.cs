using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Domain;

namespace Presenter
{
    public class DashboardPresenter : Presenter<IDashboard>
    {
        DataAccess.DA _singInDA;
        public DashboardPresenter()
        {
            _singInDA = new DA();
        }

        public List<Employee> GetEmployeeData()
        {
            try
            {
                return _singInDA.GetEmployees();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public void InitializeView()
        {
            try
            {
                SelectedView.EmployeeInfo = GetEmployeeData();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}

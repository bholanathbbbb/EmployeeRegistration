using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using ExceptionLayer;
using Newtonsoft.Json;
using Presenter;

public partial class _Default : System.Web.UI.Page, IDashboard
{
   
    private DashboardPresenter _myPresenter;

        protected void Page_Load(object sender, EventArgs e)
    {
        _myPresenter = new DashboardPresenter();
        _myPresenter.SelectedView = this;
        _myPresenter.InitializeView();
    }

    protected void SignOut_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("EmployeeSignIn.aspx");
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);
            
        }
        
    }

    public List<Employee> EmployeeInfo
    {
        set
        {
            hdnData.Value = JsonConvert.SerializeObject(value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using ExceptionLayer;
using Presenter;

public partial class _Default : System.Web.UI.Page, ISignUp
{
    private SignUpPresenter _myPresenter;
    private Employee _empInfo;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _myPresenter = new SignUpPresenter();
            _myPresenter.SelectedView = this;
            _myPresenter.InitializeView();
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);

        }
    }
    protected void SignUpNewEmployee_Click(object sender, EventArgs e)
    {
        try
        {
            _empInfo = new Employee()
            {
                UserInfo = new User()
                {
                    EmployeeNumber = employeeNumber.Value,
                    Password = password.Value
                },
                EmployeeName = employeeName.Value,
                Designation = designation.Items[designation.SelectedIndex].Text,
                Role = role.Items[role.SelectedIndex].Text,
                ServiceLine = serviceline.Items[serviceline.SelectedIndex].Text
            };


            _myPresenter.SignMeUp();

            Response.Redirect("EmployeeSignIn.aspx");
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);

        }
    }

    public Employee EmployeeInfo
    {
        get
        {
            return _empInfo;
        }
        set
        {
            _empInfo = value;
        }
    }


    List<ReferenceKey> ISignUp.FillRoleDropdown
    {
        set
        {
            role.DataSource = value;
            role.DataValueField = "RKey";
            role.DataTextField = "RValue";
            role.DataBind();
        }
    }

    List<ReferenceKey> ISignUp.FillServiceLineDropdown
    {
        set
        {
            serviceline.DataSource = value;
            serviceline.DataValueField = "RKey";
            serviceline.DataTextField = "RValue";
            serviceline.DataBind();
        }
    }

    List<ReferenceKey> ISignUp.FillDesignationDropdown
    {
        set
        {
            designation.DataSource = value;
            designation.DataValueField = "RKey";
            designation.DataTextField = "RValue";
            designation.DataBind();
        }
    }
}
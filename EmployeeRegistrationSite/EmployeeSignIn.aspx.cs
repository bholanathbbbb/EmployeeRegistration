using System;
using System.Linq;
using Domain;
using ExceptionLayer;
using Presenter;

public partial class _Default : System.Web.UI.Page, ISignIn
{
    private SignInPresenter _myPresenter;
    private User _userInfo = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            _myPresenter = new SignInPresenter();
            _myPresenter.SelectedView = this;
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);

        }
    }

    protected void SignIn_Click(object sender, EventArgs e)
    {
        try
        {
            _userInfo.EmployeeNumber = employeeNumber.Value;
            _userInfo.Password = password.Value;

            bool success = _myPresenter.SignIn();

            if (success)
            {
                Response.Redirect("EmployeeDashboard.aspx");
            }
            else
            {
                errorMsg.Style.Add("display", "block");
            }
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex);

        }
    }


    public Domain.User UserInfo
    {
        get
        {
            return _userInfo;
        }
        set
        {
            _userInfo = value;
        }
    }

    public event EventHandler SignMeUp;
}
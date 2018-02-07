using System;
using System.Linq;
using DataAccess;
using Domain;

namespace Presenter
{
    public class SignUpPresenter : Presenter<ISignUp>      
    {
        DataAccess.DA _singInDA;
        public SignUpPresenter()
        {
            _singInDA = new DA();
        }

        public bool SignMeUp()
        {
            try
            {
                if (!(_singInDA.SignIn(SelectedView.EmployeeInfo.UserInfo)))
                {
                    return _singInDA.SignUp(SelectedView.EmployeeInfo);
                }
                else
                {
                    return false;
                }
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
                SelectedView.FillRoleDropdown = _singInDA.GetReferenceValues(CommonConstants.Role);
                SelectedView.FillDesignationDropdown = _singInDA.GetReferenceValues(CommonConstants.Designation);
                SelectedView.FillServiceLineDropdown = _singInDA.GetReferenceValues(CommonConstants.ServiceLine);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
